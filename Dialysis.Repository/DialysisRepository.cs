using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
using Dialysis.Dto.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class DialysisRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public DialysisRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增透析记录
        /// </summary>
        /// <param name="dialysis"></param>
        public void Add(Domain.Models.Dialysis dialysis)
        {
            dialysis.Id = _idGenerator.CreateId();
            _context.Dialysis.Add(dialysis);
        }

        /// <summary>
        /// 获取透析记录
        /// </summary>
        /// <param name="dialysisRecordId">透析记录Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<Domain.Models.Dialysis> Get(int dialysisRecordId, long hospitalId)
        {
            return await _context.Dialysis.SingleOrDefaultAsync(t => t.DialysisRecordId == dialysisRecordId && t.HospitalId == hospitalId);
        }

        /// <summary>
        /// 获取透析记录
        /// </summary>
        /// <param name="id">透析Id</param>
        /// <returns></returns>
        public async Task<Domain.Models.Dialysis> Get(long id)
        {
            return await _context.Dialysis.SingleOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// 获取透析列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="refreshMode">0-上拉刷新（获取历史数据），1-下拉刷新（获取最新数据）</param>
        /// <param name="id">透析id（可选参数，第一次不用传）</param>
        /// <returns></returns>
        public async Task<List<Domain.Models.Dialysis>> GetDialysisList(long patientId, int pageSize, int refreshMode, long? id)
        {
            IQueryable<Domain.Models.Dialysis> query = null;
            if (id.HasValue)
            {
                switch (refreshMode)
                {
                    case (int)RefreshModeEnum.History:
                        query = _context.Dialysis.Where(t => t.PatientId == patientId && t.Id < id.Value).OrderByDescending(t => t.Id).Take(pageSize);
                        break;
                    case (int)RefreshModeEnum.New:
                        query = _context.Dialysis.Where(t => t.PatientId == patientId && t.Id > id.Value).OrderBy(t => t.Id).Take(pageSize).OrderByDescending(t => t.Id);
                        break;
                }
            }
            else
            {
                query = _context.Dialysis.Where(t => t.PatientId == patientId).OrderByDescending(t => t.Id).Take(pageSize);
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// 根据透析搜索输入分页获取透析记录
        /// </summary>
        /// <param name="input">透析搜索输入</param>
        /// <returns>透析记录列表</returns>
        public async Task<Tuple<List<Domain.Models.Dialysis>, int>> GetDialysisPageList(DialysisSearchInput input)
        {
            var query = _context.Dialysis.Include(i => i.Shift).Where(i => i.PatientId == input.PatientId);

            int total = query.Count();
            var dialysisList = await query.OrderByDescending(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<Domain.Models.Dialysis>, int>(dialysisList, total);
        }
    }
}
