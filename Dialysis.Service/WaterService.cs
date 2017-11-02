using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class WaterService
    {
        public readonly WaterRepository _repository;
        public readonly IUnitWork _unitWork;

        public WaterService(WaterRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 新增饮水量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public OutputBase Add(AddWaterInput input)
        {
            _repository.BatchAdd(input);
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 获取今日饮水量
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        public async Task<int> GetTodayDrinkVolume(long patientId)
        {
            return await _repository.GetTodayDrinkVolume(patientId);
        }

        /// <summary>
        /// 获取top数量饮水量记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>饮水量记录列表</returns>
        public async Task<List<AdminWaterDto>> GetAdminTopWaterList(CommonIndexInput input)
        {
            var waterList = await _repository.GetTopWaterList(input);

            return Mapper.Map<List<Water>, List<AdminWaterDto>>(waterList);
        }
    }
}
