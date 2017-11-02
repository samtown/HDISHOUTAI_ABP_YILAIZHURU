using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 医生职称枚举
    /// </summary>
    public enum TitleEnum
    {
        /// <summary>
        /// 主任医师
        /// </summary>
        [Display(Description = "主任医师")]
        ChiefPhysician = 1,

        /// <summary>
        /// 副主任医师
        /// </summary>
        [Display(Description = "副主任医师")]
        DeputyChiefPhysician = 2,

        /// <summary>
        /// 住院医师
        /// </summary>
        [Display(Description = "住院医师")]
        HoasePhysician = 3,

        /// <summary>
        /// 主治医师
        /// </summary>
        [Display(Description = "主治医师")]
        ResidentPhysician = 4,

        /// <summary>
        /// 护士
        /// </summary>
        [Display(Description = "护士")]
        Nurse = 5
    }
}
