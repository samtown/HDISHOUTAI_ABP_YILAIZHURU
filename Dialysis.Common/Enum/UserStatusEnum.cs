using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 患者状态枚举
    /// </summary>
    public enum UserStatusEnum
    {
        /// <summary>
        /// 未激活
        /// </summary>
        [Display(Description = "未激活")]
        UnActive = 0,

        /// <summary>
        /// 正常
        /// </summary>
        [Display(Description = "正常")]
        Normal = 1,

        /// <summary>
        /// 转院
        /// </summary>
        [Display(Description = "转院")]
        Transfer = 2,

        /// <summary>
        /// 死亡
        /// </summary>
        [Display(Description = "死亡")]
        Death = 3,

        /// <summary>
        /// 移植
        /// </summary>
        [Display(Description = "移植")]
        Transplant = 4
    }
}
