using Dialysis.Common.Enum;
using Dialysis.Dto.Admin;
using Dialysis.Dto.Common;
using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Dialysis.WebAdmin.Middleware;
using Dialysis.WebAdmin.MvcUtility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.WebAdmin.Controllers
{
    [CustomAuthentication]
    public class PatientController : BaseController
    {
        private readonly PatientService _service;
        private readonly WeightService _weightService;
        private readonly BloodPressureService _bloodPressureService;
        private readonly BloodSugarService _bloodSugarService;
        private readonly WaterService _waterService;
        private readonly HandRingService _handRingService;
        private readonly DialysisService _dialysisService;
        private readonly HospitalService _hospitalService;
        private readonly DoctorService _doctorService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public PatientController(PatientService service, WeightService weightService, BloodPressureService bloodPressureService, BloodSugarService bloodSugarService, WaterService waterService, HandRingService handRingService, DialysisService dialysisService, HospitalService hospitalService, DoctorService doctorService)
        {
            _service = service;
            _weightService = weightService;
            _bloodPressureService = bloodPressureService;
            _bloodSugarService = bloodSugarService;
            _waterService = waterService;
            _handRingService = handRingService;
            _dialysisService = dialysisService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int pageIndex = 1, long hospitalId = -1)
        {
            await ShowHospitalList(true);

            var search = new PatientSearchInput { HospitalId = hospitalId, PageIndex = pageIndex };

            return View(search);
        }

        /// <summary>
        /// 患者列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(PatientSearchInput input)
        {
            var model = new Page<PatientViewDto>();

            if (CurrentLoginUser.HospitalId.HasValue)
            {
                input.HospitalId = CurrentLoginUser.HospitalId.Value;
            }
            var items = await _service.GetPatientPageList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            ViewBag.HospitalId = input.HospitalId;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 透析列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> DialysisList(DialysisSearchInput input)
        {
            var model = new Page<AdminDialysisDto>();

            var items = await _dialysisService.GetDialysisPageList(input);
            model.CurrentPage = input.PageIndex;
            model.TotalRecords = items.Item2;
            model.Items = items.Item1;

            return PartialView("_DialysisListPartial", model);
        }

        /// <summary>
        /// 患者详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(long id, int pageIndex, long hospitalId)
        {
            ViewBag.PageIndex = pageIndex;
            ViewBag.HospitalId = hospitalId;
            var patient = await _service.GetAdminPatientDetailById(id);

            return View(patient);
        }

        /// <summary>
        /// 体重记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetWeightList(long patientId)
        {
            //默认30条最新记录
            var weightList = await _weightService.GetAdminTopWeightList(new CommonIndexInput { PatientId = patientId, TopNumber = 30 });
            weightList.Reverse();

            return Json(weightList);
        }

        /// <summary>
        /// 血压记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetBloodPressureList(long patientId)
        {
            //默认30条最新记录
            var bloodPressureList = await _bloodPressureService.GetAdminTopBloodPressureList(new CommonIndexInput { PatientId = patientId, TopNumber = 30 });
            bloodPressureList.Reverse();

            return Json(bloodPressureList);
        }

        /// <summary>
        /// 血糖记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetBloodSugarList(long patientId)
        {
            //默认30条最新记录
            var bloodSugarList = await _bloodSugarService.GetAdminTopBloodSugarList(new CommonIndexInput { PatientId = patientId, TopNumber = 30 });
            bloodSugarList.Reverse();

            return Json(bloodSugarList);
        }

        /// <summary>
        /// 饮水量记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetWaterList(long patientId)
        {
            //默认30条最新记录
            var waterList = await _waterService.GetAdminTopWaterList(new CommonIndexInput { PatientId = patientId, TopNumber = 30 });
            waterList.Reverse();

            return Json(waterList);
        }

        /// <summary>
        /// 手环记录
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetHandRingList(long patientId)
        {
            //默认30条最新记录
            var handRingList = await _handRingService.GetAdminTopHandRingList(new CommonIndexInput { PatientId = patientId, TopNumber = 30 });
            handRingList.Reverse();

            return Json(handRingList);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            await ShowHospitalList(false);
            ViewBag.SexList = EnumExtensionHelper.EnumToSelectList<SexEnum>(false);
            ViewBag.UserStatusList = EnumExtensionHelper.EnumToSelectList<UserStatusEnum>(false);
            if (id > 0)
            {
                var model = await _service.GetAdminPatientById(id);
                await ShowDoctorList(true, model.HospitalId);
                return PartialView("_EditPartial", model);
            }
            else
            {
                if (!CurrentLoginUser.IsSuperManager)
                {
                    await ShowDoctorList(true, CurrentLoginUser.HospitalId.Value);
                }
                else
                {
                    var hospitalList = await _hospitalService.GetHospitalList();
                    var hospital = hospitalList.FirstOrDefault();
                    await ShowDoctorList(true, hospital == null ? -1 : hospital.Id);
                }

                return PartialView("_EditPartial", new AdminPatientDto());
            }
        }

        /// <summary>
        /// 提交编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AdminPatientDto model)
        {
            if (!ModelState.IsValid)
            {
                await ShowHospitalList(false);
                await ShowDoctorList(true, model.HospitalId);
                ViewBag.SexList = EnumExtensionHelper.EnumToSelectList<SexEnum>(false);
                ViewBag.UserStatusList = EnumExtensionHelper.EnumToSelectList<UserStatusEnum>(false);
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
        /// <param name="isAddAll"></param>
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

        /// <summary>
        /// 医院医生列表控件
        /// </summary>
        /// <param name="isAddAll"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task ShowDoctorList(bool isAddAll, long hospitalId)
        {
            var result = await _doctorService.GetDoctorListByHospitalId(hospitalId);

            if (isAddAll)
            {
                result.Insert(0, new DictDto { Id = -1, Name = "请选择（可不选）" });
            }

            var dropdownList = new SelectList(result, "Id", "Name");
            ViewBag.DoctorList = dropdownList;
        }

        /// <summary>
        /// 获取医院医生列表(级联用)
        /// </summary>
        /// <param name="isAddAll"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetDoctorList(bool isAddAll, long hospitalId)
        {
            var result = await _doctorService.GetDoctorListByHospitalId(hospitalId);

            if (isAddAll)
            {
                result.Insert(0, new DictDto { Id = -1, Name = "请选择（可不选）" });
            }

            return Json(result);
        }
    }
}