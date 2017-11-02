using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台血糖Dto
    /// </summary>
    public class AdminBloodSugarDto
    {
        /// <summary>
        /// 血糖记录Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        public string AddTime { get; set; }
    }
}
