using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// 提示信息页面
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="message">信息内容</param>
        /// <returns></returns>
        public ActionResult Message(bool isSuccess, string message, string url)
        {
            ViewBag.IsSuccessful = isSuccess;
            ViewBag.Message = message;
            ViewBag.Url = url;

            return PartialView("_MessagePartial");
        }
    }
}
