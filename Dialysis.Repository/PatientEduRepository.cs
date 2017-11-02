using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class PatientEduRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public PatientEduRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增患教
        /// </summary>
        /// <param name="entity">患教实体</param>
        /// <returns>患教Id</returns>
        public void Add(AddCourseInput addCourseInput, long patientId, long doctorId, string batchNumber)
        {
            var id = _idGenerator.CreateId();

            var entity = new PatientEducation
            {
                Id = id,
                BatchNumber = batchNumber,
                DoctorId = doctorId,
                PatientId = patientId,
                CourseTypeId = addCourseInput.CourseTypeId,
                AddTime = DateTime.Now,
                PatientEducationDetail = new List<PatientEducationDetail>()
            };
            foreach (var item in addCourseInput.CourseIds)
            {
                entity.PatientEducationDetail.Add(new PatientEducationDetail
                {
                    CourseId = item,
                    PatientEducationId = id,
                    Id = _idGenerator.CreateId(),
                    AddTime = DateTime.Now
                });
            }
            _context.PatientEducation.Add(entity);
        }

        /// <summary>
        /// 根据外部Id获取患教实体列表
        /// </summary>
        /// <param name="outerId">外部Id</param>
        /// <returns>患教实体列表</returns>
        public async Task<List<PatientEducationDto>> GetPatientEduListByOuterId(string outerId)
        {
            string batchNumber = outerId.Substring(0, 17);//时间戳长度17
            long doctorId = Convert.ToInt64(outerId.Substring(17, 18));//长度18
            long patientId = Convert.ToInt64(outerId.Substring(35));//长度18

            var patientEduList = await _context.PatientEducation.Join(_context.Dictionary, a => a.CourseTypeId, b => b.Id, (a, b) =>
                new PatientEducationDto
                {
                    AddTime = a.AddTime,
                    BatchNumber = a.BatchNumber,
                    CourseTypeId = a.CourseTypeId,
                    CourseTypeName = b.Name,
                    DoctorId = a.DoctorId,
                    Id = a.Id,
                    PatientId = a.PatientId
                }).Where(i => i.BatchNumber == batchNumber && i.DoctorId == doctorId && i.PatientId == patientId).ToListAsync();

            return patientEduList;
        }
    }
}
