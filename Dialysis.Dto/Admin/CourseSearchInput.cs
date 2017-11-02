using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 课程搜索输入
    /// </summary>
    public class CourseSearchInput : SearchBase
    {
        /// <summary>
        /// 课程类别
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Title { get; set; }
    }
}
