using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class BloodSugarService
    {
        public readonly BloodSugarRepository _repository;
        public readonly IUnitWork _unitWork;

        public BloodSugarService(BloodSugarRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 新增血糖
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="value">血糖值</param>
        /// <returns></returns>
        public OutputBase Add(long patientId, decimal value)
        {
            _repository.Add(patientId, value);
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }


        /// <summary>
        /// 获取top数量血糖记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血糖记录列表</returns>
        public async Task<WebApiOutput<List<BloodSugarDto>>> GetTopBloodSugarList(CommonIndexInput input)
        {
            var bloodSugarList = await _repository.GetTopBloodSugarList(input);

            return WebApiOutput<List<BloodSugarDto>>.Success(Mapper.Map<List<BloodSugar>, List<BloodSugarDto>>(bloodSugarList));
        }

        /// <summary>
        /// 获取top数量血糖记录列表(后台)
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血糖记录列表</returns>
        public async Task<List<AdminBloodSugarDto>> GetAdminTopBloodSugarList(CommonIndexInput input)
        {
            var bloodSugarList = await _repository.GetTopBloodSugarList(input);

            return Mapper.Map<List<BloodSugar>, List<AdminBloodSugarDto>>(bloodSugarList);
        }
    }
}
