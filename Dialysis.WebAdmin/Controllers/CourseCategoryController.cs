using Dialysis.Dto.Admin;
using Dialysis.Dto.Common;
using Dialysis.Service;
using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class CourseCategoryController : BaseController
    {
        private readonly CourseCategoryService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public CourseCategoryController(CourseCategoryService service)
        {
            _service = service;
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
        /// 课程类别列表
        /// </summary>
        /// <param name="input">课程类别列表搜索请求</param>
        /// <returns></returns>
        public async Task<IActionResult> List(CourseCategorySearchInput input)
        {
            var model = new Page<CourseCategoryViewDto>();

            var items = await _service.GetCourseCategoryPageList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 编辑课程类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var model = await _service.GetCourseCategoryById(id);
                return PartialView("_EditPartial", model);
            }
            else
            {
                return PartialView("_EditPartial", new AdminCourseCategoryDto());
            }
        }

        /// <summary>
        /// 提交编辑课程类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AdminCourseCategoryDto model)
        {
            if (!ModelState.IsValid)
            {
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
                var result = await _service.Add(model);
                return Json(result);
            }
        }

        /// <summary>
        /// 删除课程类别
        /// </summary>
        /// <param name="id">课程类别Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return Json(result);
        }
    }
}