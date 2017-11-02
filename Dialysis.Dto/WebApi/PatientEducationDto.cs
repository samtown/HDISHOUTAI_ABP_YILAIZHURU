using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 患者教育Dto
    /// </summary>
    public class PatientEducationDto
    {
        /// <summary>
        /// 患者教育Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 医生Id
        /// </summary>
        public long DoctorId { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 课程类别Id
        /// </summary>
        public int CourseTypeId { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 课程类别名称
        /// </summary>
        public string CourseTypeName { get; set; }
    }
}
