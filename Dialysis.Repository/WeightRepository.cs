using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Linq;
using Dialysis.Common.Enum;
using System.Collections.Generic;
using Dialysis.Dto.WebApi;

namespace Dialysis.Repository
{
    public class WeightRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public WeightRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增体重
        /// </summary>
        /// <param name="weight"></param>
        public void Add(Weight weight)
        {
            weight.Id = _idGenerator.CreateId();
            _context.Weight.Add(weight);
        }

        /// <summary>
        /// 体重数据是否存在
        /// </summary>
        /// <param name="dialysisWeightId">透析体重Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<bool> IsExist(int dialysisWeightId, long hospitalId)
        {
            return await _context.Weight.AnyAsync(t => t.DialysisWeightId == dialysisWeightId && t.HospitalId == hospitalId);
        }

        /// <summary>
        /// 判断是否存在体重数据(App用)
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>是否存在</returns>
        public async Task<bool> IsExistWeightData(long patientId)
        {
            return await _context.Weight.AnyAsync(i => i.PatientId == patientId); ;
        }

        /// <summary>
        /// 根据患者Id获取最新的患者透后体重
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        public async Task<Weight> GetLatestPostDialysisWeight(long patientId)
        {
            var weigth = await _context.Weight.Where(i => i.PatientId == patientId && i.MeasureType == (int)MeasureTypeEnum.透后).OrderByDescending(i => i.MeasureTime).FirstOrDefaultAsync();

            return weigth;
        }

        /// <summary>
        /// 获取top数量体重实体列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>体重实体列表</returns>
        public async Task<List<Weight>> GetTopWeightList(CommonIndexInput input)
        {
            var weightList = await _context.Weight.Where(i => i.PatientId == input.PatientId).OrderByDescending(i => i.MeasureTime).Take(input.TopNumber).ToListAsync();

            return weightList;
        }
    }
}
