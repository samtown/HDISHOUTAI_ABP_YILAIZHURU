using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class BloodSugarRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public BloodSugarRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增血糖
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="value">血糖值</param>
        /// <returns></returns>
        public void Add(long patientId, decimal value)
        {
            var entity = new BloodSugar
            {
                Id = _idGenerator.CreateId(),
                PatientId = patientId,
                Value = value,
                AddTime = DateTime.Now
            };
            _context.BloodSugar.Add(entity);
        }

        /// <summary>
        /// 获取top数量血糖实体列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血糖实体列表</returns>
        public async Task<List<BloodSugar>> GetTopBloodSugarList(CommonIndexInput input)
        {
            var bloodSugarList = await _context.BloodSugar.Where(i => i.PatientId == input.PatientId).OrderByDescending(i => i.AddTime).Take(input.TopNumber).ToListAsync();

            return bloodSugarList;
        }

        /// <summary>
        /// 判断是否存在血糖数据(App用)
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>是否存在</returns>
        public async Task<bool> IsExistBloodSugarData(long patientId)
        {
            return await _context.BloodSugar.AnyAsync(i => i.PatientId == patientId);
        }
    }
}
