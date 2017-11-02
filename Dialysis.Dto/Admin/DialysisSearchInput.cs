using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 透析查询输入
    /// </summary>
    public class DialysisSearchInput : SearchBase
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }        
    }
}
