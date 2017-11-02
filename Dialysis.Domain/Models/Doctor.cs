using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 医护人员
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// 医护人员Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 透析医护人员Id（华墨系统Id）
        /// </summary>
        [Required]
        [StringLength(128)]
        public string DialysisDoctorId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户类型（0：医生，1：护士长，2：护士）
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 医生头像
        /// </summary>
        [StringLength(200)]
        public string DoctorFace { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? Brithdate { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 科室Id
        /// </summary>
        public int DeptId { get; set; }

        /// <summary>
        /// 职称Id
        /// </summary>
        public int TitleId { get; set; }

        /// <summary>
        /// 个人简介
        /// </summary>
        [StringLength(2000)]
        public string SelfDesc { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 医院
        /// </summary>
        public virtual Hospital Hospital { get; set; }
    }
}
