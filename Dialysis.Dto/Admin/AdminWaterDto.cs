using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 饮水量Dto
    /// </summary>
    public class AdminWaterDto
    {
        /// <summary>
        /// 饮水量Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 饮水量
        /// </summary>
        public int DrinkVolume { get; set; }

        /// <summary>
        /// 饮水时间
        /// </summary>
        public string DrinkTime { get; set; }
    }
}
