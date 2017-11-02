using Dialysis.Common;
using Dialysis.Dto.Admin;
using Dialysis.Dto.Common;
using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class CourseController : BaseController
    {
        private readonly CourseService _service;
        private readonly SystemService _systemService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public CourseController(CourseService service, SystemService systemService)
        {
            _service = service;
            _systemService = systemService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //ShowCourseCategoryList(true);

            return View();
        }

        /// <summary>
        /// 课程列表
        /// </summary>
        /// <param name="input">课程列表搜索请求</param>
        /// <returns></returns>
        public async Task<IActionResult> List(CourseSearchInput input)
        {
            var model = new Page<CourseViewDto>();

            var items = await _service.GetCoursePageList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 编辑课程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            await ShowCourseCategoryList(false);
            if (id > 0)
            {
                var model = await _service.GetCourseById(id);
                return PartialView("_EditPartial", model);
            }
            else
            {
                return PartialView("_EditPartial", new AdminCourseDto());
            }
        }

        /// <summary>
        /// 提交编辑课程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AdminCourseDto model)
        {
            if (!ModelState.IsValid)
            {
                await ShowCourseCategoryList(false);
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
        /// 删除课程
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var result = _service.Delete(id);
            return Json(result);
        }

        /// <summary>
        /// 课程类别控件
        /// </summary>
        /// <param name="isAddAll"></param>
        /// <returns></returns>
        private async Task ShowCourseCategoryList(bool isAddAll)
        {
            var result = await _systemService.GetDictionaryListByParentValue(CommConstant.PatientEduParentValue);

            if (isAddAll)
            {
                result.Insert(0, new DictDto { Id = -1, Name = "全部" });
            }

            var dropdownList = new SelectList(result, "Id", "Name");
            ViewBag.CourseCategoryList = dropdownList;
        }
    }
}