using AutoMapper;
using Dialysis.Common;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class DoctorService
    {
        public readonly DoctorRepository _repository;
        public readonly IUnitWork _unitWork;

        public DoctorService(DoctorRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 医护人员登录
        /// </summary>
        /// <param name="input">医护人员登录输入</param>
        /// <returns>医护人员登录输出</returns>
        public async Task<WebApiOutput<DoctorLoginOutput>> Login(CommonLoginInput input)
        {
            var entity = await _repository.Login(input);
            if (entity == null)
                return WebApiOutput<DoctorLoginOutput>.Fail("登录失败");
            var doctor = Mapper.Map<Doctor, DoctorLoginOutput>(entity);
            doctor.PatientCount = await _repository.GetDoctorPatientCount(entity);

            return WebApiOutput<DoctorLoginOutput>.Success(doctor);
        }

        /// <summary>
        /// 同步医护人员（新增或修改）
        /// </summary>
        /// <param name="sync"></param>
        /// <returns>是否保存成功</returns>
        public async Task<OutputBase> AddOrUpdate(AddDoctorSync sync)
        {
            var doctor = await _repository.Get(sync.DialysisDoctorId, sync.HospitalId);
            if (doctor == null)
            {
                _repository.Add(Mapper.Map<AddDoctorSync, Doctor>(sync));
            }
            else
            {
                Mapper.Map<AddDoctorSync, Doctor>(sync, doctor);
                doctor.UpdateTime = DateTime.Now;
            }

            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 根据用户类型和医院Id获取医护人员列表
        /// </summary>
        /// <param name="userType">用户类型：0：医生，1：护士长，2：护士，-1代表所有</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns>医护人员列表</returns>
        public async Task<WebApiOutput<List<DictDto>>> GetDoctorList(int userType, long hospitalId)
        {
            var doctorList = await _repository.GetDoctorList(userType, hospitalId);

            return WebApiOutput<List<DictDto>>.Success(Mapper.Map<List<Doctor>, List<DictDto>>(doctorList)); ;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="input">更新密码输入</param>
        /// <returns>是否更新成功</returns>
        public async Task<OutputBase> UpdatePassword(UpdatePasswordInput input)
        {
            await _repository.UpdatePassword(input);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

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
        /// 删除医护人员
        /// </summary>
        /// <param name="dialysisDoctorId">透析医护人员Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param> 
        /// <returns>是否保存成功</returns>
        public async Task<OutputBase> DeleteDoctor(long hospitalId, string dialysisDoctorId)
        {
            var doctor = await _repository.Get(dialysisDoctorId, hospitalId);
            if (doctor == null)
            {
                return OutputBase.Fail("该医生不存在");
            }
            _repository.Delete(doctor);
            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("该医生不存在");
        }

        /// <summary>
        /// 根据医护人员搜索输入分页获取医护人员列表
        /// </summary>
        /// <param name="input">医护人员搜索输入</param>
        /// <returns>医护人员列表</returns>
        public async Task<Tuple<List<DoctorViewDto>, int>> GetDoctorPageList(DoctorSearchInput input)
        {
            var result = await _repository.GetDoctorPageList(input);

            var tuple = new Tuple<List<DoctorViewDto>, int>(Mapper.Map<List<Doctor>, List<DoctorViewDto>>(result.Item1), result.Item2);

            return tuple;
        }

        /// <summary>
        /// 根据医护人员Id获取医护人员（后台）详情
        /// </summary>
        /// <param name="id">医护人员Id</param>
        /// <returns>医护人员</returns>
        public async Task<DoctorViewDto> GetAdminDetailDoctorById(long id)
        {
            var doctor = await _repository.GetDoctorById(id);

            return Mapper.Map<Doctor, DoctorViewDto>(doctor);
        }

        /// <summary>
        /// 根据医护人员Id获取医护人员（后台）
        /// </summary>
        /// <param name="id">医护人员Id</param>
        /// <returns>医护人员</returns>
        public async Task<AdminDoctorDto> GetAdminDoctorById(long id)
        {
            var doctor = await _repository.GetDoctorById(id);

            return Mapper.Map<Doctor, AdminDoctorDto>(doctor);
        }

        /// <summary>
        /// 新增医护人员
        /// </summary>
        /// <param name="input">医护人员信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Add(AdminDoctorDto input)
        {
            if (await _repository.GetDoctorByPhone(input.Phone) != null)
                return OutputBase.Fail("该手机号已经注册");

            var doctor = new Doctor
            {
                Brithdate = input.Brithdate,
                DeptId = input.DeptId,
                HospitalId = input.HospitalId,
                Name = input.Name,
                Phone = input.Phone,
                SelfDesc = input.SelfDesc,
                Sex = input.Sex,
                UserType = input.UserType,
                TitleId = input.TitleId,
                DialysisDoctorId = string.Empty,//默认
                IsDelete = false
            };
            _repository.Add(doctor);

            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 更新医护人员
        /// </summary>
        /// <param name="input">医护人员信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Update(AdminDoctorDto input)
        {
            var doctor = await _repository.GetDoctorById(input.Id);
            if (doctor == null)
                return OutputBase.Fail("该医护人员不存在");
            if (doctor.Phone != input.Phone && await _repository.GetDoctorByPhone(input.Phone) != null)
                return OutputBase.Fail("该手机号已经注册");

            var entity = new Doctor
            {
                Id = input.Id,
                Brithdate = input.Brithdate,
                DeptId = input.DeptId,
                HospitalId = input.HospitalId,
                Name = input.Name,
                Phone = input.Phone,
                SelfDesc = input.SelfDesc,
                Sex = input.Sex,
                UserType = input.UserType,
                TitleId = input.TitleId
            };
            await _repository.Update(entity);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 删除医护人员
        /// </summary>
        /// <param name="id">医护人员Id</param>
        /// <returns>是否成功</returns>
        public OutputBase Delete(long id)
        {
            _repository.Delete(id);

            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }

        /// <summary>
        /// 获取医院医生列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<DictDto>> GetDoctorListByHospitalId(long hospitalId)
        {
            var doctorList = await _repository.GetDoctorList(-1, hospitalId);

            return Mapper.Map<List<Doctor>, List<DictDto>>(doctorList);
        }
    }
}
