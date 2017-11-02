using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台省份Dto
    /// </summary>
    public class AdminProvinceDto
    {
        /// <summary>
        /// 省份Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
    }
}
