using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddWaterInput
    /// </summary>
    public class AddWaterInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// 饮水
        /// </summary>
        public List<Drink> Drink { get; set; }
    }

    /// <summary>
    /// 饮水
    /// </summary>
    public class Drink
    {
        /// <summary>
        /// 饮水量
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "饮水量必须大于0")]
        public int DrinkVolume { get; set; }

        /// <summary>
        /// 饮水时间
        /// </summary>
        [Required]
        public DateTime DrinkTime { get; set; }
    }
}
