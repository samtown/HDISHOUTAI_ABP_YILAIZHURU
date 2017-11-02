using System.ComponentModel.DataAnnotations;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 刷新方式枚举
    /// </summary>
    public enum RefreshModeEnum
    {
        /// <summary>
        /// 上拉刷新（获取历史数据）
        /// </summary>
        [Display(Description = "上拉刷新")]
        History = 0,

        /// <summary>
        /// 下拉刷新（获取最新数据）
        /// </summary>
        [Display(Description = "下拉刷新")]
        New = 1
    }
}
