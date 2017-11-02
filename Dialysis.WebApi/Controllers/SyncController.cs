using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 数据同步接口
    /// </summary>
    [Produces("application/json")]
    [Route("api/Sync")]
    public class SyncController : Controller
    {
        private readonly ShiftService _shiftService;
        private readonly DoctorService _doctorService;
        private readonly PatientService _patientService;
        private readonly PatientContactService _patientContactService;
        private readonly DialysisService _dialysisService;
        private readonly BloodPressureService _bloodPressureService;
        private readonly WeightService _weightService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="shiftService"></param>
        /// <param name="doctorService"></param>
        /// <param name="patientService"></param>
        /// <param name="patientContactService"></param>
        /// <param name="dialysisService"></param>
        /// <param name="bloodPressureService"></param>
        /// <param name="weightService"></param>
        public SyncController(ShiftService shiftService, DoctorService doctorService, PatientService patientService, PatientContactService patientContactService,
            DialysisService dialysisService, BloodPressureService bloodPressureService, WeightService weightService)
        {
            _shiftService = shiftService;
            _doctorService = doctorService;
            _patientService = patientService;
            _patientContactService = patientContactService;
            _dialysisService = dialysisService;
            _bloodPressureService = bloodPressureService;
            _weightService = weightService;
        }

        /// <summary>
        /// 同步排班
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("Shift")]
        public async Task<OutputBase> SyncShift([FromBody]AddShiftSync sync)
        {
            return await _shiftService.AddOrUpdate(sync);
        }

        /// <summary>
        /// 同步医护人员
        /// </summary>
        /// <param name="sync"></param>
        /// <returns>是否保存成功</returns>
        [HttpPost("Doctor")]
        public async Task<OutputBase> SyncDoctor([FromBody]AddDoctorSync sync)
        {
            return await _doctorService.AddOrUpdate(sync);
        }

        /// <summary>
        /// 删除医护人员
        /// </summary>
        /// <param name="hospitalId">医院Id</param> 
        /// <param name="dialysisDoctorId">透析医护人员Id（华墨系统Id）</param>
        /// <returns>是否保存成功</returns>
        [HttpDelete("Doctor/{hospitalId}/{dialysisDoctorId}")]
        public async Task<OutputBase> DeleteDoctor(long hospitalId, string dialysisDoctorId)
        {
            return await _doctorService.DeleteDoctor(hospitalId, dialysisDoctorId);
        }

        /// <summary>
        /// 同步患者
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("Patient")]
        public async Task<OutputBase> SyncPatient([FromBody]AddPatientSync sync)
        {
            return await _patientService.AddOrUpdate(sync);
        }

        /// <summary>
        /// 同步患者联系人
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("PatientContact")]
        public async Task<OutputBase> SyncPatientContact([FromBody]AddPatientContactSync sync)
        {
            return await _patientContactService.AddOrUpdate(sync);
        }

        /// <summary>
        /// 同步透析上机
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("DialysisOn")]
        public async Task<OutputBase> SyncDialysisOn([FromBody]AddDialysisOnSync sync)
        {
            return await _dialysisService.AddDialysisOn(sync);
        }

        /// <summary>
        /// 同步透析下机
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("DialysisOff")]
        public async Task<OutputBase> SyncDialysisOff([FromBody]AddDialysisOffSync sync)
        {
            return await _dialysisService.AddDialysisOff(sync);
        }

        /// <summary>
        /// 同步透析小结
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("DialysisSummary")]
        public async Task<OutputBase> SyncDialysisSummary([FromBody]AddDialysisSummarySync sync)
        {
            return await _dialysisService.AddDialysisSummary(sync);
        }

        /// <summary>
        /// 同步血压
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("BloodPressure")]
        public async Task<OutputBase> SyncBloodPressure([FromBody]AddBloodPressureSync sync)
        {
            return await _bloodPressureService.Add(sync);
        }

        /// <summary>
        /// 同步体重
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        [HttpPost("Weight")]
        public async Task<OutputBase> SyncWeight([FromBody]AddWeightSync sync)
        {
            return await _weightService.Add(sync);
        }
    }
}