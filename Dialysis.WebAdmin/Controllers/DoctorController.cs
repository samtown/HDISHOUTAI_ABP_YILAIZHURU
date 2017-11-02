using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dialysis.Service;
using Dialysis.Dto.Common;
using Dialysis.Dto.Admin;
using Dialysis.WebAdmin.Middleware;
using Dialysis.WebAdmin.MvcUtility;
using Dialysis.Common.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dialysis.Dto.WebApi;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class DoctorController : BaseController
    {
        private readonly DoctorService _service;
        private readonly HospitalService _hospitalService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public DoctorController(DoctorService service, HospitalService hospitalService)
        {
            _service = service;
            _hospitalService = hospitalService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int pageIndex = 1, long hospitalId = -1)
        {
            await ShowHospitalList(true);

            var search = new DoctorSearchInput { HospitalId = hospitalId, PageIndex = pageIndex };

            return View(search);
        }

        /// <summary>
        /// 医生列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(DoctorSearchInput input)
        {
            var model = new Page<DoctorViewDto>();

            if (CurrentLoginUser.HospitalId.HasValue)
            {
                input.HospitalId = CurrentLoginUser.HospitalId.Value;
            }
            var items = await _service.GetDoctorPageList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            ViewBag.HospitalId = input.HospitalId;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 医生详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(long id, int pageIndex, long hospitalId)
        {
            ViewBag.PageIndex = pageIndex;
            ViewBag.HospitalId = hospitalId;
            var doctor = await _service.GetAdminDetailDoctorById(id);

            return View(doctor);
        }

        /// <summary>
        /// 编辑医生
        /// </summary>
        /// <param name = "id" >医生Id</ param >
        /// < returns ></ returns >
        public async Task<IActionResult> Edit(long id)
        {
            await ShowHospitalList(false);
            ViewBag.SexList = EnumExtensionHelper.EnumToSelectList<SexEnum>(false);
            ViewBag.UserTypeList = EnumExtensionHelper.EnumToSelectList<UserTypeEnum>(false);
            ViewBag.DeptList = EnumExtensionHelper.EnumToSelectList<DeptEnum>(false);
            ViewBag.TitleList = EnumExtensionHelper.EnumToSelectList<TitleEnum>(false);
            if (id > 0)
            {
                var model = await _service.GetAdminDoctorById(id);
                return PartialView("_EditPartial", model);
            }
            else
            {
                return PartialView("_EditPartial", new AdminDoctorDto());
            }
        }

        /// <summary>
        /// 提交编辑医生
        /// </summary>
        /// <param name = "model" ></ param >
        /// < returns ></ returns >
        [HttpPost]
        public async Task<IActionResult> Edit(AdminDoctorDto model)
        {
            if (!ModelState.IsValid)
            {
                await ShowHospitalList(false);
                ViewBag.SexList = EnumExtensionHelper.EnumToSelectList<SexEnum>(false);
                ViewBag.UserTypeList = EnumExtensionHelper.EnumToSelectList<UserTypeEnum>(false);
                ViewBag.DeptList = EnumExtensionHelper.EnumToSelectList<DeptEnum>(false);
                ViewBag.TitleList = EnumExtensionHelper.EnumToSelectList<TitleEnum>(false);
                return PartialView("_EditPartial", model);
            }

            if (model.HospitalId < 1 && !CurrentLoginUser.IsSuperManager)
            {
                model.HospitalId = CurrentLoginUser.HospitalId.Value;
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
        /// 医院列表控件
        /// </summary>
        /// <param name="isAddAll">是否包含全部</param>
        /// <returns></returns>
        private async Task ShowHospitalList(bool isAddAll)
        {
            var result = await _hospitalService.GetHospitalList();

            if (isAddAll)
            {
                result.Insert(0, new DictDto { Id = -1, Name = "全部" });
            }

            var dropdownList = new SelectList(result, "Id", "Name");
            ViewBag.HospitalList = dropdownList;
        }
    }
}