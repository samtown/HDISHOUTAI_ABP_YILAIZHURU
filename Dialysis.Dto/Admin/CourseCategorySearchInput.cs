using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 课程类别查询输入
    /// </summary>
    public class CourseCategorySearchInput: SearchBase
    {
        /// <summary>
        /// 课程类别名称
        /// </summary>
        public string CategoryName { get; set; }
    }
}
