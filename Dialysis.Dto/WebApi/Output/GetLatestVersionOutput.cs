using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi.Output
{
    /// <summary>
    /// 获取最新版本
    /// </summary>
    public class GetLatestVersionOutput
    {
        /// <summary>
        /// 是否存在新版本
        /// </summary>
        public bool IsExistNewVersion
        {
            get
            {
                return !string.IsNullOrEmpty(VersionName);
            }
        }

        /// <summary>
        /// 版本名称
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// 更新日志
        /// </summary>
        public string UpdateLog { get; set; }

        /// <summary>
        /// 版本更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 文件MD5
        /// </summary>
        public string FileMD5 { get; set; }
    }
}
