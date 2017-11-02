using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 食物速查输入
    /// </summary>
    public class FoodSearchInput
    {
        /// <summary>
        /// 食物类别
        /// </summary>
        public int FoodType { get; set; }

        /// <summary>
        /// 食物名称
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 分页页号（从1开始）
        /// </summary>
        public int PageIndex { get; set; } = 1;
    }
}
