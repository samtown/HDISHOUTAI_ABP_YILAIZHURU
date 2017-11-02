using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// App刷新数据基类
    /// </summary>
    public class AppRefreshBase
    {
        /// <summary>
        /// 刷新方式：0-上拉刷新（获取历史数据），1-下拉刷新（获取最新数据）
        /// </summary>
        public int RefreshMode { get; set; }

        /// <summary>
        /// 每页数据量
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 起始Id
        /// </summary>
        public long? StartId { get; set; }
    }
}
