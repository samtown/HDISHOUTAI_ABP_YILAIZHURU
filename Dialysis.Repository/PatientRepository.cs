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
    public class PatientRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public PatientRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增患者
        /// </summary>
        /// <param name="patient">患者</param>
        /// <returns></returns>
        public long Add(Patient patient)
        {
            DateTime now = DateTime.Now;
            patient.Id = _idGenerator.CreateId();
            patient.AddTime = now;
            patient.UpdateTime = now;
            _context.Patient.Add(patient);

            return patient.Id;
        }

        /// <summary>
        /// 更新患者
        /// </summary>
        /// <param name="patient">患者</param>
        /// <returns></returns>
        public async Task Update(Patient patient)
        {
            var entity = await _context.Patient.FindAsync(patient.Id);
            entity.UpdateTime = DateTime.Now;
            _context.Patient.Update(patient);
        }

        /// <summary>
        /// 更新患者
        /// </summary>
        /// <param name="patient">患者</param>
        /// <returns></returns>
        public async Task UpdatePatient(Patient patient)
        {
            var entity = await _context.Patient.FindAsync(patient.Id);
            entity.Brithdate = patient.Brithdate;
            entity.DoctorId = patient.DoctorId;
            entity.HospitalId = patient.HospitalId;
            entity.PatientName = patient.PatientName;
            entity.PinyinCode = patient.PinyinCode;
            entity.Remark = patient.Remark;
            entity.Sex = patient.Sex;
            entity.UserStatus = patient.UserStatus;
            entity.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 删除患者
        /// </summary>
        /// <param name="id">患者id</param>
        /// <returns></returns>
        public void Delete(long id)
        {
            _context.Patient.Remove(new Patient { Id = id });
        }

        /// <summary>
        /// 获取患者
        /// </summary>
        /// <param name="dialysisPatientId">透析患者Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<Patient> Get(int dialysisPatientId, long hospitalId)
        {
            return await _context.Patient.Where(t => t.DialysisPatientId == dialysisPatientId && t.HospitalId == hospitalId).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 患者登陆
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="password">密码</param>
        /// <returns>患者登录输出</returns>
        public async Task<PatientContact> Login(string phone, string password)
        {
            return await _context.PatientContact.Include(t => t.Patient).ThenInclude(t => t.Hospital)
                  .SingleOrDefaultAsync(i => i.MobilePhone == phone && i.Password == password.ToUpper());
        }

        /// <summary>
        /// 根据患者Id获取患者实体
        /// </summary>
        /// <param name="id">患者Id</param>
        /// <returns>患者实体</returns>
        public async Task<Patient> GetPatientById(long id)
        {
            var patient = await _context.Patient.Include(i => i.Hospital).Include(i => i.Doctor).Include(i => i.PatientContacts).Where(i => i.Id == id).FirstOrDefaultAsync();

            return patient;
        }

        public async Task<PatientContact> GetPatientCotactByPhone(string phone)
        {
            var contact = await _context.PatientContact.Where(i => i.MobilePhone == phone).FirstOrDefaultAsync();

            return contact;
        }

        public async Task<PatientContact> GetPatientCotactById(long id)
        {
            var contact = await _context.PatientContact.Where(i => i.PatientId == id).FirstOrDefaultAsync();

            return contact;
        }

        /// <summary>
        /// 更新患者状态
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        public async Task UpdateUserStatus(long patientId)
        {
            var patient = await _context.Patient.FindAsync(patientId);
            patient.UserStatus = (int)UserStatusEnum.Normal;
            patient.UpdateTime = DateTime.Now;
        }

        ///// <summary>
        ///// 更新密码
        ///// </summary>
        ///// <param name="input">更新密码输入</param>
        ///// <returns></returns>
        //public async Task UpdatePassword(UpdatePasswordInput input)
        //{
        //    var patient = await _context.Patient.FindAsync(input.Id);
        //    patient.Password = input.Password;
        //    patient.UpdateTime = DateTime.Now;
        //}

        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="input">更新头像输入</param>
        /// <returns></returns>
        public async Task UpdateFace(UpdateFaceInput input)
        {
            var patient = await _context.Patient.FindAsync(input.Id);
            patient.PatientFace = input.Face;
            patient.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 更新体重
        /// </summary>
        /// <param name="input">更新体重输入</param>
        /// <returns></returns>
        public async Task UpdateWeight(UpdateWeightInput input)
        {
            var patient = await _context.Patient.FindAsync(input.PatientId);
            patient.Weight = input.Weight;
            patient.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 更新身高
        /// </summary>
        /// <param name="input">更新身高输入</param>
        /// <returns></returns>
        public async Task UpdateHeight(UpdateHeightInput input)
        {
            var patient = await _context.Patient.FindAsync(input.PatientId);
            patient.Height = input.Height;
            patient.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 根据患者列表输入获取患者实体列表
        /// </summary>
        /// <param name="input">患者列表输入</param>
        /// <returns>患者实体列表</returns>
        public async Task<List<Patient>> GetPatientListByDoctor(PatientListInput input)
        {
            var patientList = await _context.Patient.Where(i => (input.UserType == (int)UserTypeEnum.Nurse ? i.DoctorId == input.DoctorId : true) && i.HospitalId == input.HospitalId).ToListAsync();

            return patientList;
        }

        /// <summary>
        /// 根据患者搜索输入分页获取患者实体列表
        /// </summary>
        /// <param name="input">患者搜索输入</param>
        /// <returns>患者实体列表</returns>
        public async Task<Tuple<List<Patient>, int>> GetPatientPageList(PatientSearchInput input)
        {
            var query = _context.Patient.Include(i => i.Hospital).Include(i => i.Doctor).AsQueryable();

            if (!string.IsNullOrEmpty(input.PatientName))
            {
                query = query.Where(i => i.PatientName.Contains(input.PatientName));
            }
            if (input.Sex != -1)
            {
                query = query.Where(i => i.Sex == input.Sex);
            }
            if (input.UserStatus != -1)
            {
                query = query.Where(i => i.UserStatus == input.UserStatus);
            }
            if (input.HospitalId != -1)
            {
                query = query.Where(i => i.HospitalId == input.HospitalId);
            }

            int total = query.Count();
            var patientList = await query.OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<Patient>, int>(patientList, total);
        }

        /// <summary>
        /// 修改水杯MAC
        /// </summary>
        /// <param name="input"></param>
        /// <returns>是否成功</returns>
        public async Task UpdateCupMAC(UpdateCupMACInput input)
        {
            var patient = await _context.Patient.FindAsync(input.PatientId);
            patient.CupMAC = input.CupMAC;
            patient.UpdateTime = DateTime.Now;
        }
    }
}
