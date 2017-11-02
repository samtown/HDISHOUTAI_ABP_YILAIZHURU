using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Dto.WebApi.Input;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class HandRingService
    {
        public readonly HandRingRepository _repository;
        public readonly PatientRepository _patientRepository;
        public readonly IUnitWork _unitWork;

        public HandRingService(HandRingRepository repository, PatientRepository patientRepository, IUnitWork unitWork)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 添加手环数据
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public async Task<OutputBase> Add(AddHandRingInput input)
        {
            if (await _patientRepository.GetPatientById(input.PatientId) == null)
                return OutputBase.Fail("患者不存在");

            foreach (var item in input.HandRingList)
            {
                if (!await _repository.IsExsit(input.PatientId, item.Date))
                {
                    var entity = new HandRing
                    {
                        Date = item.Date,
                        Distance = item.Distance,
                        Energy = item.Energy,
                        SleepTime = item.SleepTime,
                        Steps = item.Steps,
                        PatientId = input.PatientId
                    };

                    _repository.Add(entity);
                }
            }
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 获取top数量手环记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>手环记录列表</returns>
        public async Task<List<AdminHandRingDto>> GetAdminTopHandRingList(CommonIndexInput input)
        {
            var waterList = await _repository.GetTopHandRingList(input);

            return Mapper.Map<List<HandRing>, List<AdminHandRingDto>>(waterList);
        }
    }
}
