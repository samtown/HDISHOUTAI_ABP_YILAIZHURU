using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 患教
    /// </summary>
    [Produces("application/json")]
    [Route("api/PatientEdu")]
    public class PatientEduController : Controller
    {
        private readonly PatientEduService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public PatientEduController(PatientEduService service)
        {
            _service = service;
        }

        /// <summary>
        /// 保存患教
        /// </summary>
        /// <param name="input">患教输入</param>
        /// <returns>是否成功</returns>
        [HttpPost]
        public async Task<OutputBase> Add([FromBody]AddPatientEduInput input)
        {
            return await _service.Add(input);
        }

        /// <summary>
        /// 根据课程Id获取课程详情
        /// </summary>
        /// <param name="courseId">课程Id</param>
        /// <returns>课程详情</returns>
        [HttpGet("Course/{courseId}")]
        public async Task<WebApiOutput<CourseDto>> GetCourseById(long courseId)
        {
            return await _service.GetCourseById(courseId);
        }

        /// <summary>
        /// 获取患教课程列表（课程类别+该课程类别下课程）
        /// </summary>
        /// <returns>课程类别对应的课程列表</returns>
        [HttpGet("CourseList")]
        public async Task<WebApiOutput<List<CourseListOutput>>> GetCourseList()
        {
            return await _service.GetCourseList();
        }

        /// <summary>
        /// 根据外部Id获取患教课程列表（课程类别+该课程类别下课程）
        /// </summary>
        /// <param name="outerId">外部Id</param>
        /// <returns>课程类别对应的课程列表</returns>
        [HttpGet("CourseList/{outerId}")]
        public async Task<WebApiOutput<List<CourseListOutput>>> GetCourseListByOuterId(string outerId)
        {
            return await _service.GetCourseListByOuterId(outerId);
        }
    }
}