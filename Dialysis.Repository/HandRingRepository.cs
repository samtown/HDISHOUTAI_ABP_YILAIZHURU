using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class HandRingRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public HandRingRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public void Add(HandRing entity)
        {
            entity.Id = _idGenerator.CreateId();

            _context.HandRing.Add(entity);
        }

        /// <summary>
        /// 是否存在数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<bool> IsExsit(long patientId, DateTime date)
        {
            return await _context.HandRing.AnyAsync(i => i.PatientId == patientId && i.Date == date);
        }

        /// <summary>
        /// 获取top数量手环数据实体列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>手环数据实体列表</returns>
        public async Task<List<HandRing>> GetTopHandRingList(CommonIndexInput input)
        {
            var handRingList = await _context.HandRing.Where(i => i.PatientId == input.PatientId).OrderByDescending(i => i.Date).Take(input.TopNumber).ToListAsync();

            return handRingList;
        }
    }
}
