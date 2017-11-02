using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class CourseRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public CourseRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="entity">课程实体</param>
        public void Add(Course entity)
        {
            entity.Id = _idGenerator.CreateId();
            entity.AddTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;

            _context.Course.Add(entity);
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id">课程Id</param>
        public void Delete(long id)
        {
            _context.Course.Remove(new Course { Id = id });
        }


        /// <summary>
        /// 更新课程
        /// </summary>
        /// <param name="entity">课程实体</param>
        /// <returns></returns>
        public async Task Update(Course entity)
        {
            var course = await _context.Course.FindAsync(entity.Id);
            course.Content = entity.Content;
            course.Logo = entity.Logo;
            course.Title = entity.Title;
            course.Type = entity.Type;
            course.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 获取同课程类别下课程最大SortId
        /// </summary>
        /// <param name="coursType">课程类别</param>
        /// <returns></returns>
        public async Task<int> GetCourseMaxSortId(int coursType)
        {
            int max = await (from c in _context.Course
                             where c.Type == coursType
                             select c.SortId).MaxAsync();

            return max;
        }

        /// <summary>
        /// 根据课程Id获取课程实体
        /// </summary>
        /// <param name="id">课程Id</param>
        /// <returns>课程实体</returns>
        public async Task<Course> GetCourseById(long id)
        {
            var course = await _context.Course.FindAsync(id);

            return course;
        }

        /// <summary>
        /// 根据课程类型获取课程实体列表
        /// </summary>
        /// <param name="courseType">课程类型</param>
        /// <returns>课程实体列表</returns>
        public async Task<List<Course>> GetCourseListByCourseType(int courseType)
        {
            var courseList = await _context.Course.Where(i => i.Type == courseType).OrderBy(i => i.SortId).ToListAsync();

            return courseList;
        }

        /// <summary>
        /// 根据患教Id获取课程实体列表
        /// </summary>
        /// <param name="patientEduId">患教Id</param>
        /// <returns>课程实体列表</returns>
        public async Task<List<Course>> GetCourseListByPatientEduId(long patientEduId)
        {
            var courseList = await (from c in _context.Course
                                    join ped in _context.PatientEducationDetail on c.Id equals ped.CourseId
                                    where ped.PatientEducationId == patientEduId
                                    orderby c.SortId
                                    select c).ToListAsync();

            return courseList;
        }

        /// <summary>
        /// 根据课程搜索输入分页获取课程实体列表
        /// </summary>
        /// <param name="input">课程搜索输入</param>
        /// <returns>课程实体列表</returns>
        public async Task<Tuple<List<CourseViewDto>, int>> GetCoursePageList(CourseSearchInput input)
        {
            var query = _context.Course.Join(_context.Dictionary, a => a.Type, b => b.Id, (a, b) =>
                new CourseViewDto
                {
                    Category = a.Type,
                    CategoryName = b.Name,
                    Title = a.Title,
                    Id = a.Id
                });

            if (input.Category != -1)
            {
                query = query.Where(i => i.Category == input.Category);
            }
            if (!string.IsNullOrEmpty(input.Title))
            {
                query = query.Where(i => i.Title.Contains(input.Title));
            }

            int total = query.Count();
            var courseList = await query.OrderBy(i => i.Title).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<CourseViewDto>, int>(courseList, total);
        }
    }
}
