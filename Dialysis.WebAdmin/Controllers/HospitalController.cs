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
    public class HospitalController : BaseController
    {
        private readonly HospitalService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public HospitalController(HospitalService service)
        {
            _service = service;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ////搜索
            //ShowProvinceList(true);
            //ShowCityList(true, -1);

            return View();
        }

        /// <summary>
        /// 医院列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(HospitalSearchInput input)
        {
            var model = new Page<HospitalViewDto>();

            var items = await _service.GetHospitalPageList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 编辑医院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            await ShowProvinceList(false);
            if (id > 0)
            {
                var model = await _service.GetHospitalById(id);
                await ShowCityList(false, model.ProvinceId);
                return PartialView("_EditPartial", model);
            }
            else
            {
                await ShowCityList(false, 1);
                return PartialView("_EditPartial", new AdminHospitalDto());
            }
        }

        /// <summary>
        /// 提交编辑医院
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AdminHospitalDto model)
        {
            if (!ModelState.IsValid)
            {
                await ShowProvinceList(false);
                await ShowCityList(false, model.ProvinceId);
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
        /// 删除医院
        /// </summary>
        /// <param name="id">医院Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var result = _service.Delete(id);
            return Json(result);
        }

        /// <summary>
        /// 省份城市级联
        /// </summary>
        /// <param name="isAddAll"></param>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetCityList(bool isAddAll, int provinceId)
        {
            var result = await _service.GetCityListByProvinceId(provinceId);
            if (isAddAll)
                result.Insert(0, new AdminCityDto { Id = -1, CityName = "全部" });

            return Json(result);
        }

        /// <summary>
        /// 省份控件
        /// </summary>
        /// <param name="isAddAll"></param>
        /// <returns></returns>
        private async Task ShowProvinceList(bool isAddAll)
        {
            var result = await _service.GetProvinceList();

            if (isAddAll)
            {
                result.Insert(0, new AdminProvinceDto { Id = -1, ProvinceName = "全部" });
            }

            var dropdownList = new SelectList(result, "Id", "ProvinceName");
            ViewBag.ProvinceList = dropdownList;
        }

        /// <summary>
        /// 城市控件
        /// </summary>
        /// <param name="isAddAll"></param>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        private async Task ShowCityList(bool isAddAll, int provinceId)
        {
            var result = await _service.GetCityListByProvinceId(provinceId);

            if (isAddAll)
            {
                result.Insert(0, new AdminCityDto { Id = -1, CityName = "全部" });
            }

            var dropdownList = new SelectList(result, "Id", "CityName");
            ViewBag.CityList = dropdownList;
        }
    }
}