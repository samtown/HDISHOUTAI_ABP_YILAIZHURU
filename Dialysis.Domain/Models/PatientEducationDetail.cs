using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 患者教育详情
    /// </summary>
    public class PatientEducationDetail
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 患者教育Id
        /// </summary>
        public long PatientEducationId { get; set; }

        /// <summary>
        /// 课程Id
        /// </summary>
        public long CourseId { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// 患教
        /// </summary>
        public virtual PatientEducation PatientEducation { get; set; }
    }
}
