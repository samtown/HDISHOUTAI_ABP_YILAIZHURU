using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    public enum MeasureMethodEnum
    {
        /// <summary>
        /// 手工
        /// </summary>
        [Display(Description = "手工")]
        手工 = 0,

        /// <summary>
        /// 自助
        /// </summary>
        [Display(Description = "自助")]
        自助 = 1,

        /// <summary>
        /// 血透机
        /// </summary>
        [Display(Description = "血透机")]
        血透机 = 2,

        /// <summary>
        /// 监护仪
        /// </summary>
        [Display(Description = "监护仪")]
        监护仪 = 3,

        /// <summary>
        /// App
        /// </summary>
        [Display(Description = "App")]
        App = 99,
    }
}
