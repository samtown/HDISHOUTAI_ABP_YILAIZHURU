using log4net;
using log4net.Config;
using System;
using System.IO;

namespace Dialysis.Common
{
    public class LogHelper
    {
        private const string Repository = "NetCoreRepository";
        private const string InfoLogger = "LogInfo";
        private const string ErrorLogger = "LogError";

        /// <summary>
        /// 配置log4net
        /// </summary>
        /// <param name="fileName">配置文件名称</param>
        public static void SetConfig(string fileName)
        {
            XmlConfigurator.Configure(LogManager.CreateRepository(Repository), new FileInfo(fileName));
        }

        /// <summary>
        /// 记录Info
        /// </summary>
        /// <param name="message"></param>
        public static void WriteInfo(string message)
        {
            var logger = LogManager.GetLogger(Repository, InfoLogger);
            if (logger.IsInfoEnabled)
            {
                logger.Info(message);
            }
        }

        /// <summary>
        /// 记录Error
        /// </summary>
        /// <param name="message"></param>
        public static void WriteError(string message)
        {
            var logger = LogManager.GetLogger(Repository, ErrorLogger);
            if (logger.IsErrorEnabled)
            {
                logger.Error(message);
            }
        }

        /// <summary>
        /// 记录Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteError(string message, Exception ex)
        {
            var logger = LogManager.GetLogger(Repository, ErrorLogger);
            if (logger.IsErrorEnabled)
            {
                logger.Error(message, ex);
            }
        }
    }
}
