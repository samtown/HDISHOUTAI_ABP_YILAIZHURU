using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 修改头像
    /// </summary>
    public class UpdateFaceInput
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Required(ErrorMessage = "头像不能为空")]
        public string Face { get; set; }
    }
}
