using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Dialysis.Repository
{
    public class PatientContactRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public PatientContactRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 获取患者联系人
        /// </summary>
        /// <param name="dialysisContactId">透析患者联系人Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<PatientContact> Get(int dialysisContactId, long hospitalId)
        {
            return await _context.PatientContact.SingleOrDefaultAsync(t => t.DialysisContactId == dialysisContactId && t.HospitalId == hospitalId);
        }

        /// <summary>
        /// 新增患者联系人
        /// </summary>
        /// <param name="patientContact">患者联系人</param>
        /// <returns></returns>
        public void Add(PatientContact patientContact)
        {
            patientContact.Id = _idGenerator.CreateId();
            patientContact.Password = CommConstant.InitialPassword;
            patientContact.AddTime = DateTime.Now;
            patientContact.UpdateTime = DateTime.Now;
            _context.PatientContact.Add(patientContact);
        }

        /// <summary>
        /// 更新患者联系人
        /// </summary>
        /// <param name="patientContact">患者联系人</param>
        /// <returns></returns>
        public async Task Update(PatientContact patientContact)
        {
            var contact = await _context.PatientContact.Where(i => i.PatientId == patientContact.PatientId).FirstOrDefaultAsync();
            //contact.Password = patientContact.Password;
            contact.MobilePhone = patientContact.MobilePhone;
            contact.ContatctName = patientContact.ContatctName;
            contact.UpdateTime = DateTime.Now;
        }
    }
}
