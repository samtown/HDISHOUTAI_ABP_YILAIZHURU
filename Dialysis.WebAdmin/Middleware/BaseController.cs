using Dialysis.Common;
using Dialysis.Dto.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Dialysis.WebAdmin.Middleware
{
    public class BaseController : Controller
    {
        public AdminLoginUserInfo CurrentLoginUser
        {
            get
            {
                return HttpContext.Session.Get<AdminLoginUserInfo>(CommConstant.AdminLoginCurrentUser);
            }
        }
    }
}
