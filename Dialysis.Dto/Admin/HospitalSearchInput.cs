using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 医院搜索输入
    /// </summary>
    public class HospitalSearchInput : SearchBase
    {
        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
    }
}
