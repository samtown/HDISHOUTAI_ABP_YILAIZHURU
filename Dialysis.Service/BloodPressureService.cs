using AutoMapper;
using Dialysis.Common.Enum;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class BloodPressureService
    {
        public readonly BloodPressureRepository _repository;
        public readonly PatientRepository _patientRepository;
        public readonly IUnitWork _unitWork;

        public BloodPressureService(BloodPressureRepository repository, PatientRepository patientRepository, IUnitWork unitWork)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 同步血压
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> Add(AddBloodPressureSync sync)
        {
            if (await _repository.IsExist(sync.DialysisBloodPressureId, sync.HospitalId))
            {
                return OutputBase.Fail("此血压数据已存在");
            }

            var patient = await _patientRepository.Get(sync.DialysisPatientId, sync.HospitalId);
            if (patient == null)
            {
                return OutputBase.Fail("此患者不存在");
            }

            var bloodPressure = Mapper.Map<AddBloodPressureSync, BloodPressure>(sync);
            bloodPressure.PatientId = patient.Id;
            _repository.Add(bloodPressure);
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public OutputBase Add(AddBloodPressureInput input)
        {
            var bloodPressure = Mapper.Map<AddBloodPressureInput, BloodPressure>(input);
            bloodPressure.MeasureType = (int)MeasureTypeEnum.日常;
            bloodPressure.MeasureMethod = (int)MeasureMethodEnum.App;
            _repository.Add(bloodPressure);
            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 获取top数量血压记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血压记录列表</returns>
        public async Task<WebApiOutput<List<BloodPressureDto>>> GetTopBloodPressureList(CommonIndexInput input)
        {
            var bloodPressureList = await _repository.GetTopBloodPressureList(input);

            return WebApiOutput<List<BloodPressureDto>>.Success(Mapper.Map<List<BloodPressure>, List<BloodPressureDto>>(bloodPressureList));
        }

        /// <summary>
        /// 获取top数量血压记录列表
        /// </summary>
        /// <param name="input">公共指标输入</param>
        /// <returns>血压记录列表</returns>
        public async Task<List<AdminBloodPressureDto>> GetAdminTopBloodPressureList(CommonIndexInput input)
        {
            var bloodPressureList = await _repository.GetTopBloodPressureList(input);

            return Mapper.Map<List<BloodPressure>, List<AdminBloodPressureDto>>(bloodPressureList);
        }
    }
}
