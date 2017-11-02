using Dialysis.Dto.Admin;
using Dialysis.Dto.Common;
using Dialysis.Service;
using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class SystemController : BaseController
    {
        private readonly SystemService _service;
        private readonly HospitalService _hospitalService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public SystemController(SystemService service, HospitalService hospitalService)
        {
            _service = service;
            _hospitalService = hospitalService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 后台用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(AdministratorSearchInput input)
        {
            var model = new Page<AdministratorViewDto>();

            var items = await _service.GetAdministratorList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 编辑后台用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            await ShowHospitalList();
            if (id > 0)
            {
                var model = await _service.GetAdministrator(id);
                return PartialView("_EditPartial", model);
            }
            else
            {
                return PartialView("_EditPartial", new AdministratorDto());
            }
        }

        /// <summary>
        /// 提交编辑后台用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AdministratorDto model)
        {
            if (!ModelState.IsValid)
            {
                await ShowHospitalList();
                return PartialView("_EditPartial", model);
            }

            //主键初始Id大于0表示是编辑，反之则是新增
            if (model.Id > 0)
            {
                var result = await _service.Update(model);
                return Json(result);
            }
            else
            {
                var result = _service.Add(model);
                return Json(result);
            }
        }

        /// <summary>
        /// 删除后台患者
        /// </summary>
        /// <param name="id">患者Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var result = _service.Delete(id);
            return Json(result);
        }

        /// <summary>
        /// 医院列表控件
        /// </summary>
        /// <returns></returns>
        private async Task ShowHospitalList()
        {
            ViewBag.HospitalList = new SelectList(await _hospitalService.GetHospitalList(), "Id", "Name");
        }
    }
}