using Dialysis.Common;
using Dialysis.Dto.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dialysis.WebApi.Middleware
{
    /// <summary>
    /// 自定义异常处理
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            LogHelper.WriteError("请求异常", context.Exception);
            context.Result = new OkObjectResult(OutputBase.Fail("请求发生错误"));
        }
    }
}
