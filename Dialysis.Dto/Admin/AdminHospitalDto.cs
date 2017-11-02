using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台医院Dto
    /// </summary>
    public class AdminHospitalDto
    {
        /// <summary>
        /// 医院Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [Required(ErrorMessage = "请输入医院名称")]
        public string HospitalName { get; set; }

        /// <summary>
        /// 省份Id
        /// </summary>
        public int ProvinceId { get; set; }
    }
}
