using Microsoft.AspNetCore.Builder;

namespace Dialysis.WebApi.Middleware
{
    /// <summary>
    /// RequestLogger扩展
    /// </summary>
    public static class RequestLoggerExtensions
    {
        /// <summary>
        /// 记录HTTP请求日志
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
