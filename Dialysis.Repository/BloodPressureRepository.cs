using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dialysis.Dto.WebApi;

namespace Dialysis.Repository
{
    public class BloodPressureRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public BloodPressureRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="bloodPressure"></param>
        public void Add(BloodPressure bloodPressure)
        {
            bloodPressure.Id = _idGenerator.CreateId();
            _context.BloodPressure.Add(bloodPressure);
        }

        /// <summary>
        /// 血压数据是否存在
        /// </summary>
        /// <param name="dialysisBloodPressureId">透析血压Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<bool> IsExist(int dialysisBloodPressureId, long hospitalId)
        {
            return await _context.BloodPressure.AnyAsync(t => t.DialysisBloodPressureId == dialysisBloodPressureId && t.HospitalId == hospitalId);
        }

        /// <summary>
        /// 判断是否存在血压数据(App用)
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>是否存在</returns>
        public async Task<bool> IsExistBloodPressureData(long patientId)
        {
            return await _context.BloodPressure.AnyAsync(i => i.PatientId == patientId);
        }

        /// <summary>
        /// 获取top数量血压实体列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血压实体列表</returns>
        public async Task<List<BloodPressure>> GetTopBloodPressureList(CommonIndexInput input)
        {
            var bloodPressureList = await _context.BloodPressure.Where(i => i.PatientId == input.PatientId).OrderByDescending(i => i.MeasureTime).Take(input.TopNumber).ToListAsync();

            return bloodPressureList;
        }
    }
}
