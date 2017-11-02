using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 更新身高
    /// </summary>
    public class UpdateHeightInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [Range(50d, 250d, ErrorMessage = "请输入正常身高范围")]
        public decimal Height { get; set; }
    }
}
