using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台课程类别Dto
    /// </summary>
    public class AdminCourseCategoryDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入课程类别名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required(ErrorMessage = "请输入课程类别说明")]
        public string Description { get; set; }
    }
}
