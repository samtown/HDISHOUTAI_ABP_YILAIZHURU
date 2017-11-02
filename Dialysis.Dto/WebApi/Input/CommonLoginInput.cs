using Dialysis.Common;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// APP公用登录输入
    /// </summary>
    public class CommonLoginInput
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "请输入手机号")]
        [RegularExpression(RegexHelper.CheckMobileRegex, ErrorMessage = "请输入正确的手机号码")]
        public string Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
    }
}
