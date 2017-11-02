using System.Collections.Generic;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 课程列表
    /// </summary>
    public class CourseListOutput
    {
        /// <summary>
        /// 患教课程类别
        /// </summary>
        public int CourseType { get; set; }

        /// <summary>
        /// 患教课程类别名称
        /// </summary>
        public string CourseTypeName { get; set; }

        /// <summary>
        /// 课程列表
        /// </summary>
        public List<CourseDto> CourseList { get; set; }
    }
}
