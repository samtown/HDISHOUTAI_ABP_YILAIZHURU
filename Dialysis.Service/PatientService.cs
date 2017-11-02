using AutoMapper;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class PatientService
    {
        public readonly PatientRepository _repository;
        public readonly WeightRepository _weightRepository;
        public readonly BloodPressureRepository _bloodPressureRepository;
        public readonly BloodSugarRepository _bloodSugarRepository;
        public readonly PatientContactRepository _patientContactRepository;
        public readonly IUnitWork _unitWork;
        public readonly OssRepository _ossRepository;

        public PatientService(PatientRepository repository, WeightRepository weightRepository, BloodPressureRepository bloodPressureRepository, BloodSugarRepository bloodSugarRepository, PatientContactRepository patientContactRepository, IUnitWork unitWork, OssRepository ossRepository)
        {
            _repository = repository;
            _weightRepository = weightRepository;
            _bloodPressureRepository = bloodPressureRepository;
            _bloodSugarRepository = bloodSugarRepository;
            _patientContactRepository = patientContactRepository;
            _unitWork = unitWork;
            _ossRepository = ossRepository;
        }

        /// <summary>
        /// 同步患者
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddOrUpdate(AddPatientSync sync)
        {
            var patient = await _repository.Get(sync.DialysisPatientId, sync.HospitalId);
            if (patient == null)
            {
                patient = Mapper.Map<AddPatientSync, Patient>(sync);
                _repository.Add(patient);
            }
            else
            {
                patient.UpdateTime = DateTime.Now;
                Mapper.Map(sync, patient);
            }
            if (sync.PatientFace != null && sync.PatientFace.Length > 0)
            {
                patient.PatientFace = await _ossRepository.UploadPatientAvatar(patient.Id, sync.PatientFace);
            }

            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 患者登录
        /// </summary>
        /// <param name="input">患者登录输入</param>
        /// <returns>患者登录输出</returns>
        public async Task<WebApiOutput<PatientLoginOutput>> Login(CommonLoginInput input)
        {
            var patientContact = await _repository.Login(input.Phone, input.Password);
            if (patientContact == null)
            {
                return WebApiOutput<PatientLoginOutput>.Fail("登陆失败");
            }
            if (patientContact.Patient.UserStatus == (int)UserStatusEnum.UnActive)
            {
                await _repository.UpdateUserStatus(patientContact.PatientId);
                return _unitWork.Commit() ? WebApiOutput<PatientLoginOutput>.Success(Mapper.Map<PatientContact, PatientLoginOutput>(patientContact), "登陆成功") : WebApiOutput<PatientLoginOutput>.Fail("登陆失败");
            }

            return WebApiOutput<PatientLoginOutput>.Success(Mapper.Map<PatientContact, PatientLoginOutput>(patientContact), "登陆成功");
        }

        ///// <summary>
        ///// 更新密码
        ///// </summary>
        ///// <param name="input">更新密码输入</param>
        ///// <returns>是否更新成功</returns>
        //public async Task<OutputBase> UpdatePassword(UpdatePasswordInput input)
        //{
        //    await _repository.UpdatePassword(input);

        //    return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        //}

        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="input">更新头像输入</param>
        /// <returns>是否更新成功</returns>
        public async Task<WebApiOutput<string>> UpdateFace(UpdateFaceInput input)
        {
            await _repository.UpdateFace(input);

            return _unitWork.Commit() ? WebApiOutput<string>.Success(CommConstant.OssUrl + input.Face, "上传头像成功") : WebApiOutput<string>.Fail("上传头像失败");
        }

        /// <summary>
        /// 更新身高
        /// </summary>
        /// <param name="input">更新身高输入</param>
        /// <returns>是否更新成功</returns>
        public async Task<OutputBase> UpdateHeight(UpdateHeightInput input)
        {
            await _repository.UpdateHeight(input);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 更新体重
        /// </summary>
        /// <param name="input">更新体重输入</param>
        /// <returns>是否更新成功</returns>
        public async Task<OutputBase> UpdateWeight(UpdateWeightInput input)
        {
            await _repository.UpdateWeight(input);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据患者列表输入获取患者基本信息列表
        /// </summary>
        /// <param name="input">患者列表输入</param>
        /// <returns>患者基本信息列表</returns>
        public async Task<WebApiOutput<List<PatientBaseDto>>> GetPatientListByDoctor(PatientListInput input)
        {
            var patientList = await _repository.GetPatientListByDoctor(input);

            return WebApiOutput<List<PatientBaseDto>>.Success(Mapper.Map<List<Patient>, List<PatientBaseDto>>(patientList));
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        public async Task<WebApiOutput<PatientDto>> GetPatientById(long patientId)
        {
            var patient = Mapper.Map<Patient, PatientDto>(await _repository.GetPatientById(patientId));
            patient.HasWeightData = await _weightRepository.IsExistWeightData(patientId);
            patient.HasBloodPressureData = await _bloodPressureRepository.IsExistBloodPressureData(patientId);
            patient.HasBloodSugarData = await _bloodSugarRepository.IsExistBloodSugarData(patientId);

            return WebApiOutput<PatientDto>.Success(patient);
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息（后台）详情
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        public async Task<PatientDetailViewDto> GetAdminPatientDetailById(long patientId)
        {
            var entity = await _repository.GetPatientById(patientId);
            var patient = Mapper.Map<Patient, PatientDetailViewDto>(entity);
            if (entity != null)
            {
                var content = string.Empty;
                foreach (var item in entity.PatientContacts)
                {
                    content += item.Relationship + " " + item.ContatctName + " " + item.MobilePhone + "；";
                }
                patient.ContactContent = string.IsNullOrEmpty(content) ? "暂无" : content.TrimEnd('；');
            }

            return patient;
        }

        /// <summary>
        /// 根据患者Id获取患者详细信息（后台）
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns>患者详细信息</returns>
        public async Task<AdminPatientDto> GetAdminPatientById(long patientId)
        {
            var patient = Mapper.Map<Patient, AdminPatientDto>(await _repository.GetPatientById(patientId));

            return patient;
        }

        /// <summary>
        /// 根据患者搜索输入分页获取患者列表
        /// </summary>
        /// <param name="input">患者搜索输入</param>
        /// <returns>患者列表</returns>
        public async Task<Tuple<List<PatientViewDto>, int>> GetPatientPageList(PatientSearchInput input)
        {
            var result = await _repository.GetPatientPageList(input);

            var tuple = new Tuple<List<PatientViewDto>, int>(Mapper.Map<List<Patient>, List<PatientViewDto>>(result.Item1), result.Item2);

            return tuple;
        }

        /// <summary>
        /// 修改水杯MAC
        /// </summary>
        /// <param name="input"></param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> UpdateCupMAC(UpdateCupMACInput input)
        {
            await _repository.UpdateCupMAC(input);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 新增患者
        /// </summary>
        /// <param name="input">患者信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Add(AdminPatientDto input)
        {
            if (await _repository.GetPatientCotactByPhone(input.Phone) != null)
                return OutputBase.Fail("该手机号已经注册");

            var patient = new Patient
            {
                Brithdate = input.Brithdate,
                DialysisPatientId = 0,//默认
                DoctorId = input.DoctorId == -1 ? null : input.DoctorId,
                HospitalId = input.HospitalId,
                PatientName = input.PatientName,
                PinyinCode = Utility.GetFirstPY(input.PatientName),
                Remark = input.Remark,
                Sex = input.Sex,
                UserStatus = input.UserStatus
            };
            var patientId = _repository.Add(patient);
            var contact = new PatientContact
            {
                MobilePhone = input.Phone,
                Relationship = CommConstant.OneselfRelationship,
                ContatctName = input.PatientName,
                DialysisContactId = 0,//默认
                HospitalId = input.HospitalId,
                PatientId = patientId
            };
            _patientContactRepository.Add(contact);

            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 更新患者
        /// </summary>
        /// <param name="input">患者信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Update(AdminPatientDto input)
        {
            var patientContact = await _repository.GetPatientCotactById(input.Id);
            if (input.Phone != patientContact.MobilePhone && await _repository.GetPatientCotactByPhone(input.Phone) != null)
                return OutputBase.Fail("该手机号已经注册");

            var patient = new Patient
            {
                Id = input.Id,
                Brithdate = input.Brithdate,
                DoctorId = input.DoctorId == -1 ? null : input.DoctorId,
                HospitalId = input.HospitalId,
                PatientName = input.PatientName,
                PinyinCode = Utility.GetFirstPY(input.PatientName),
                Remark = input.Remark,
                Sex = input.Sex,
                UserStatus = input.UserStatus
            };
            await _repository.UpdatePatient(patient);
            var contact = new PatientContact
            {
                MobilePhone = input.Phone,
                ContatctName = input.PatientName,
                //Password = input.Password,
                PatientId = input.Id
            };
            await _patientContactRepository.Update(contact);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 删除患者
        /// </summary>
        /// <param name="id">患者Id</param>
        /// <returns>是否成功</returns>
        public OutputBase Delete(long id)
        {
            _repository.Delete(id);

            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }
    }
}
