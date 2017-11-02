using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 资讯
    /// </summary>
    public class InfomationDto
    {
        /// <summary>
        /// 资讯Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 资讯标题
        /// </summary>
        public string InfoTitle { get; set; }

        /// <summary>
        /// 资讯Logo
        /// </summary>
        public string InfoLogo { get; set; }

        /// <summary>
        /// 资讯内容
        /// </summary>
        public string InfoContent { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
