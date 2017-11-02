using Dialysis.Dto.WebApi;
using Dialysis.H5.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Threading.Tasks;

namespace Dialysis.H5.Controllers
{
    public class CourseController : Controller
    {
        private readonly MyOptions _optionsAccessor;

        public CourseController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 课程详情
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [StaticFileHandlerFilter(Key = "courseId")]
        [HttpGet]
        public async Task<IActionResult> Detail(long courseId)
        {
            var request = new RestRequest();
            request.Resource = "/api/PatientEdu/Course/{courseId}";
            request.AddParameter("courseId", courseId, ParameterType.UrlSegment);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<CourseDto>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return View(response.ResultValue);
            }
            return View(new CourseDto());
        }
    }
}