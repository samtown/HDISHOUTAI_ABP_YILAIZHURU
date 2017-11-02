using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class StatisticsController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 活跃度
        /// </summary>
        /// <returns></returns>
        public IActionResult Activity()
        {
            return View();
        }
    }
}