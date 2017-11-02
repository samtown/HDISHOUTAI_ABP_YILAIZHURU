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
    public class WaterRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public WaterRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 批量新增饮水量
        /// </summary>
        /// <param name="input"></param>
        public void BatchAdd(AddWaterInput input)
        {
            List<Water> waterList = new List<Water>();
            DateTime currentTime = DateTime.Now;
            foreach (var item in input.Drink)
            {
                waterList.Add(new Water
                {
                    Id = _idGenerator.CreateId(),
                    PatientId = input.PatientId,
                    DrinkVolume = item.DrinkVolume,
                    DrinkTime = item.DrinkTime,
                    AddTime = currentTime
                });
            }
            _context.Water.AddRange(waterList);
        }

        /// <summary>
        /// 获取今日饮水量
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        public async Task<int> GetTodayDrinkVolume(long patientId)
        {
            var currentDate = DateTime.Now.Date;

            return await _context.Water.Where(t => t.PatientId == patientId && t.DrinkTime >= currentDate && t.DrinkTime < currentDate.AddDays(1)).SumAsync(t => t.DrinkVolume);
        }

        /// <summary>
        /// 获取top数量饮水量实体列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>饮水量实体列表</returns>
        public async Task<List<Water>> GetTopWaterList(CommonIndexInput input)
        {
            var waterList = await _context.Water.Where(i => i.PatientId == input.PatientId).OrderByDescending(i => i.DrinkTime).Take(input.TopNumber).ToListAsync();

            return waterList;
        }
    }
}
