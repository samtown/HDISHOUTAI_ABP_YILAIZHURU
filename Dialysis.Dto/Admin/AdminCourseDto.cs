using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台课程Dto
    /// </summary>
    public class AdminCourseDto
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
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请输入课程标题")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "请输入课程内容")]
        public string Content { get; set; }
    }
}
