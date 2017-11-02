using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 系统字典搜索输入
    /// </summary>
    public class DictionarySearchInput : SearchBase
    {
        /// <summary>
        /// 父键
        /// </summary>
        public int ParentValue { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
