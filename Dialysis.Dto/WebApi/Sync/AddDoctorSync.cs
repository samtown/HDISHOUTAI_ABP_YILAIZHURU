using Dialysis.Common;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddDoctorSync
    /// </summary>
    public class AddDoctorSync
    {
        /// <summary>
        /// 透析医护人员Id（华墨系统Id）
        /// </summary>
        [Required]
        [StringLength(128)]
        public string DialysisDoctorId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

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
        [RegularExpression(RegexHelper.CheckMobileRegex, ErrorMessage = "手机号码不正确")]
        public string Phone { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        [Range(0, 1, ErrorMessage = "性别不正确")]
        [Required]
        public int Sex { get; set; }
    }
}
