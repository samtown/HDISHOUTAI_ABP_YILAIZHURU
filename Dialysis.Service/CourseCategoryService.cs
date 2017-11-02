using AutoMapper;
using Dialysis.Common;
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
    public class CourseCategoryService
    {
        public readonly SystemRepository _systemRepository;
        public readonly IUnitWork _unitWork;

        public CourseCategoryService(SystemRepository systemRepository, IUnitWork unitWork)
        {
            _unitWork = unitWork;
            _systemRepository = systemRepository;
        }

        /// <summary>
        /// 新建课程类别
        /// </summary>
        /// <param name="model">课程类别信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Add(AdminCourseCategoryDto model)
        {
            int value = await _systemRepository.GetMaxIdByParentValue(CommConstant.PatientEduParentValue);
            int sortId = await _systemRepository.GetMaxSortIdByParentValue(CommConstant.PatientEduParentValue);
            var entity = new Dictionary
            {
                Id = value == 0 ? 1 : (value + 1),
                Description = model.Description,
                Name = model.Name,
                ParentValue = CommConstant.PatientEduParentValue,
                SortId = sortId == 0 ? 1 : (sortId + 1)
            };
            _systemRepository.AddDictionary(entity);

            return _unitWork.Commit() ? OutputBase.Success("新增课程类别成功") : OutputBase.Fail("新增课程类别失败");
        }

        /// <summary>
        /// 更新课程类别
        /// </summary>
        /// <param name="model">课程类别信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Update(AdminCourseCategoryDto model)
        {
            var entity = new Dictionary
            {
                Description = model.Description,
                Name = model.Name,
                Id = model.Id
            };
            await _systemRepository.UpdateDictionary(entity);

            return _unitWork.Commit() ? OutputBase.Success("更新课程类别成功") : OutputBase.Fail("更新课程类别失败");
        }

        /// <summary>
        /// 删除课程类别
        /// </summary>
        /// <param name="courseCategoryId">课程类别Id</param>
        /// <returns>是否成功</returns>
        public OutputBase Delete(int courseCategoryId)
        {
            _systemRepository.DeleteDictionary(courseCategoryId);

            return _unitWork.Commit() ? OutputBase.Success("删除课程类别成功") : OutputBase.Fail("删除课程类别失败");
        }

        /// <summary>
        /// 根据课程类别Id获取课程类别
        /// </summary>
        /// <param name="courseCategoryId">课程类别Id</param>
        /// <returns>课程类别</returns>
        public async Task<AdminCourseCategoryDto> GetCourseCategoryById(int courseCategoryId)
        {
            var category = await _systemRepository.GetDictionaryById(courseCategoryId);

            return Mapper.Map<Dictionary, AdminCourseCategoryDto>(category);
        }

        /// <summary>
        /// 根据课程类别搜索输入分页获取课程类别列表
        /// </summary>
        /// <param name="input">课程类别搜索输入</param>
        /// <returns>课程类别列表</returns>
        public async Task<Tuple<List<CourseCategoryViewDto>, int>> GetCourseCategoryPageList(CourseCategorySearchInput input)
        {
            var newInput = new DictionarySearchInput { Name = input.CategoryName, PageIndex = input.PageIndex, PageSize = input.PageSize, ParentValue = CommConstant.PatientEduParentValue };
            var result = await _systemRepository.GetDictionaryPageList(newInput);

            var tuple = new Tuple<List<CourseCategoryViewDto>, int>(Mapper.Map<List<Dictionary>, List<CourseCategoryViewDto>>(result.Item1), result.Item2);

            return tuple;
        }
    }
}
