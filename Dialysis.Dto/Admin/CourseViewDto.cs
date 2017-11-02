using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 课程显示Dto
    /// </summary>
    public class CourseViewDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }
}
