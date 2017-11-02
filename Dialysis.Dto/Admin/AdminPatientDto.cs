using Dialysis.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台患者Dto
    /// </summary>
    public class AdminPatientDto
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 透析患者Id（华墨系统Id）
        /// </summary>
        public int DialysisPatientId { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string PatientName { get; set; }

        /// <summary>
        /// 患者姓名拼音码
        /// </summary>
        public string PinyinCode { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 用户状态（0：未激活，1：正常，2：转院，3：死亡，4：移植）
        /// </summary>
        public int UserStatus { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Brithdate { get; set; } = new DateTime(1970, 1, 1);

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 所属医护人员Id
        /// </summary>
        public long? DoctorId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "请输入手机号")]
        [RegularExpression(RegexHelper.CheckMobileRegex, ErrorMessage = "请输入正确的手机号码")]
        public string Phone { get; set; }
    }
}
