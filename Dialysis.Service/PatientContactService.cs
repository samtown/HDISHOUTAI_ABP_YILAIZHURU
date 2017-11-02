using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class PatientContactService
    {
        public readonly PatientContactRepository _repository;
        public readonly PatientRepository _patientRepository;
        public readonly IUnitWork _unitWork;

        public PatientContactService(PatientContactRepository repository, PatientRepository patientRepository, IUnitWork unitWork)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 同步患者联系人(新增或修改)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddOrUpdate(AddPatientContactSync sync)
        {
            var patient = await _patientRepository.Get(sync.DialysisPatientId, sync.HospitalId);
            if (patient == null)
            {
                return OutputBase.Fail("不存在该患者");
            }

            var patientContact = await _repository.Get(sync.DialysisContactId, sync.HospitalId);
            if (patientContact == null)
            {
                var entity = Mapper.Map<AddPatientContactSync, PatientContact>(sync);
                entity.PatientId = patient.Id;
                _repository.Add(entity);
            }
            else
            {
                patientContact.PatientId = patient.Id;
                patientContact.UpdateTime = DateTime.Now;
                Mapper.Map(sync, patientContact);
            }

            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }
    }
}
