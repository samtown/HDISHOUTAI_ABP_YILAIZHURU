using Dialysis.Dto.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.H5.Controllers
{
    public class BloodPressureController : Controller
    {
        private readonly MyOptions _optionsAccessor;

        public BloodPressureController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 血压列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> List(long patientId)
        {
            var request = new RestRequest();
            request.Resource = "api/Patient/{patientId}";
            request.AddParameter("patientId", patientId, ParameterType.UrlSegment);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<PatientDto>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return View(response.ResultValue);
            }
            throw new ArgumentNullException("patientId");
        }

        /// <summary>
        /// 获取血压列表
        /// </summary>
        /// <param name="topNumber">top数量</param>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList(string topNumber, long patientId)
        {
            var request = new RestRequest();
            request.Resource = "/api/BloodPressure/{topNumber}/{patientId}";
            request.AddParameter("topNumber", topNumber, ParameterType.UrlSegment);
            request.AddParameter("patientId", patientId, ParameterType.UrlSegment);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<List<BloodPressureDto>>>(request);
            if (response.IsSuccess && response.ResultValue != null && response.ResultValue.Count > 0)
            {
                response.ResultValue.Reverse();
                return Json(response.ResultValue);
            }
            return Json(new List<BloodPressureDto>());
        }
    }
}