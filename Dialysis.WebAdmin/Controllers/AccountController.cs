using Dialysis.Common;
using Dialysis.Dto.Admin;
using Dialysis.Service;
using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dialysis.WebAdmin.Controllers
{

    public class AccountController : Controller
    {
        private readonly SystemService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public AccountController(SystemService service)
        {
            _service = service;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginInput model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUser = await _service.Login(model);
            if (currentUser != null)
            {
                HttpContext.Session.Set(CommConstant.AdminLoginCurrentUser, currentUser);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "用户名或密码错误");
            return View();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [CustomAuthentication]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(CommConstant.AdminLoginCurrentUser);
            return RedirectToAction("Login", "Account");
        }
    }
}