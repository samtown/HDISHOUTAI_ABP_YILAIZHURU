using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class DoctorRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public DoctorRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 医护人员登陆
        /// </summary>
        /// <param name="input">医护人员登录输入</param>
        /// <returns>医护人员登录输出</returns>
        public async Task<Doctor> Login(CommonLoginInput input)
        {
            var doctor = await _context.Doctor.Where(i => i.Phone == input.Phone && i.Password == input.Password.ToUpper()).Include(i => i.Hospital).FirstOrDefaultAsync();

            return doctor;
        }

        /// <summary>
        /// 新增医护人员
        /// </summary>
        /// <param name="entity">医护人员实体</param>
        public void Add(Doctor entity)
        {
            entity.Id = _idGenerator.CreateId();
            entity.Password = CommConstant.InitialPassword;
            entity.AddTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;

            _context.Doctor.Add(entity);
        }

        /// <summary>
        /// 删除医护人员
        /// </summary>
        /// <param name="id">医护人员Id</param>
        public void Delete(long id)
        {
            _context.Doctor.Remove(new Doctor { Id = id });
        }

        /// <summary>
        /// 更新医护人员
        /// </summary>
        /// <param name="entity">医护人员实体</param>
        public async Task Update(Doctor entity)
        {
            var doctor = await _context.Doctor.FindAsync(entity.Id);
            doctor.Brithdate = entity.Brithdate;
            doctor.DeptId = entity.DeptId;
            doctor.HospitalId = entity.HospitalId;
            doctor.Name = entity.Name;
            doctor.Phone = entity.Phone;
            doctor.SelfDesc = entity.SelfDesc;
            doctor.Sex = entity.Sex;
            doctor.TitleId = entity.TitleId;
            doctor.UpdateTime = DateTime.Now;
            doctor.UserType = entity.UserType;
        }

        /// <summary>
        /// 获取医护人员的患者数量
        /// </summary>
        /// <param name="doctor">医护人员信息</param>
        /// <returns>数量</returns>
        public async Task<int> GetDoctorPatientCount(Doctor doctor)
        {
            var count = await _context.Patient.CountAsync(i => doctor.UserType == (int)UserTypeEnum.Nurse ? i.DoctorId == doctor.Id : i.HospitalId == doctor.HospitalId);

            return count;
        }

        /// <summary>
        /// 根据医护人员Id获取医护人员实体
        /// </summary>
        /// <param name="id">医护人员Id</param>
        /// <returns>医护人员实体</returns>
        public async Task<Doctor> GetDoctorById(long id)
        {
            var doctor = await _context.Doctor.Include(i => i.Hospital).Where(i => i.Id == id).FirstOrDefaultAsync();

            return doctor;
        }

        /// <summary>
        /// 根据医护人员手机号获取医护人员实体
        /// </summary>
        /// <param name="phone">医护人员手机号</param>
        /// <returns>医护人员实体</returns>
        public async Task<Doctor> GetDoctorByPhone(string phone)
        {
            var doctor = await _context.Doctor.Where(i => i.Phone == phone).FirstOrDefaultAsync();

            return doctor;
        }

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <param name="dialysisDoctorId">透析医护人员Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<Doctor> Get(string dialysisDoctorId, long hospitalId)
        {
            return await _context.Doctor.SingleOrDefaultAsync(t => t.DialysisDoctorId == dialysisDoctorId && t.HospitalId == hospitalId);
        }

        /// <summary>
        /// 根据用户类型和医院Id获取医护人员实体列表
        /// </summary>
        /// <param name="userType">用户类型：0：医生，1：护士长，2：护士，-1代表所有</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns>医护人员实体列表</returns>
        public async Task<List<Doctor>> GetDoctorList(int userType, long hospitalId)
        {
            var doctorList = await _context.Doctor.Where(i => i.HospitalId == hospitalId && (userType != -1 ? i.UserType == userType : true)).ToListAsync();

            return doctorList;
        }

        /// <summary>
        /// 根据医护人员搜索输入分页获取医护人员实体列表
        /// </summary>
        /// <param name="input">医护人员搜索输入</param>
        /// <returns>医护人员实体列表</returns>
        public async Task<Tuple<List<Doctor>, int>> GetDoctorPageList(DoctorSearchInput input)
        {
            var query = _context.Doctor.Include(i => i.Hospital).AsQueryable();

            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.Where(i => i.Name.Contains(input.Name));
            }
            if (!string.IsNullOrEmpty(input.Phone))
            {
                query = query.Where(i => i.Phone.Contains(input.Phone));
            }
            if (input.Sex != -1)
            {
                query = query.Where(i => i.Sex == input.Sex);
            }
            if (input.UserType != -1)
            {
                query = query.Where(i => i.UserType == input.UserType);
            }
            if (input.HospitalId != -1)
            {
                query = query.Where(i => i.HospitalId == input.HospitalId);
            }
            if (input.DeptId != -1)
            {
                query = query.Where(i => i.DeptId == input.DeptId);
            }
            if (input.TitleId != -1)
            {
                query = query.Where(i => i.TitleId == input.TitleId);
            }

            int total = query.Count();
            var doctorList = await query.OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<Doctor>, int>(doctorList, total);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="input">更新密码输入</param>
        /// <returns></returns>
        public async Task UpdatePassword(UpdatePasswordInput input)
        {
            var doctor = await _context.Doctor.FindAsync(input.Id);
            doctor.Password = input.Password;
            doctor.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="input">更新头像输入</param>
        /// <returns></returns>
        public async Task UpdateFace(UpdateFaceInput input)
        {
            var doctor = await _context.Doctor.FindAsync(input.Id);
            doctor.DoctorFace = input.Face;
            doctor.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 删除医生（逻辑删除）
        /// </summary>
        /// <param name="doctor"></param>
        public void Delete(Doctor doctor)
        {
            doctor.IsDelete = true;
            doctor.UpdateTime = DateTime.Now;
        }
    }
}
