using Dialysis.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台医护人员Dto
    /// </summary>
    public class AdminDoctorDto
    {
        /// <summary>
        /// 医护人员Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 透析医护人员Id（华墨系统Id）
        /// </summary>
        public string DialysisDoctorId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "请输入手机号")]
        [RegularExpression(RegexHelper.CheckMobileRegex, ErrorMessage = "请输入正确的手机号码")]
        public string Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
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
        /// 出生日期
        /// </summary>
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
    }
}
