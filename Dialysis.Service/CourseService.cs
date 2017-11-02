using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class CourseService
    {
        public readonly CourseRepository _repository;
        public readonly IUnitWork _unitWork;

        public CourseService(CourseRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 根据课程Id获取课程
        /// </summary>
        /// <param name="courseId">课程Id</param>
        /// <returns>课程信息</returns>
        public async Task<AdminCourseDto> GetCourseById(long courseId)
        {
            var course = await _repository.GetCourseById(courseId);

            return Mapper.Map<Course, AdminCourseDto>(course);
        }

        /// <summary>
        /// 新建课程
        /// </summary>
        /// <param name="model">课程信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Add(AdminCourseDto model)
        {
            var sortId = await _repository.GetCourseMaxSortId(model.Category);
            var entity = new Course
            {
                Content = model.Content,
                SortId = sortId == 0 ? 1 : (sortId + 1),
                Title = model.Title,
                Type = model.Category
            };
            _repository.Add(entity);

            return _unitWork.Commit() ? OutputBase.Success("新增课程成功") : OutputBase.Fail("新增课程失败");
        }

        /// <summary>
        /// 更新课程信息
        /// </summary>
        /// <param name="model">课程信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Update(AdminCourseDto model)
        {
            var entity = new Course
            {
                Content = model.Content,
                Title = model.Title,
                Type = model.Category,
                Id = model.Id
            };
            await _repository.Update(entity);

            return _unitWork.Commit() ? OutputBase.Success("更新课程成功") : OutputBase.Fail("更新课程失败");
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="courseId">课程Id</param>
        /// <returns>是否成功</returns>
        public OutputBase Delete(long courseId)
        {
            _repository.Delete(courseId);

            return _unitWork.Commit() ? OutputBase.Success("删除课程成功") : OutputBase.Fail("删除课程失败");
        }

        /// <summary>
        /// 根据课程搜索输入分页获取课程信息列表
        /// </summary>
        /// <param name="input">课程搜索输入</param>
        /// <returns>课程信息列表</returns>
        public async Task<Tuple<List<CourseViewDto>, int>> GetCoursePageList(CourseSearchInput input)
        {
            var result = await _repository.GetCoursePageList(input);

            var tuple = new Tuple<List<CourseViewDto>, int>(result.Item1, result.Item2);

            return tuple;
        }
    }
}
