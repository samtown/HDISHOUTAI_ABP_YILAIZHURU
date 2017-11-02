using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 患者教育
    /// </summary>
    public class PatientEducation
    {
        /// <summary>
        /// 患者教育Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [Required]
        [StringLength(50)]
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
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 医护人员
        /// </summary>
        public virtual Doctor Doctor { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual ICollection<PatientEducationDetail> PatientEducationDetail { get; set; }
    }
}
