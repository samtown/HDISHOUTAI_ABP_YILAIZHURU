using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 消息搜索输入
    /// </summary>
    public class MessageSearchInput : AppRefreshBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }
    }
}
