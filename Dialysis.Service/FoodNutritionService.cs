using AutoMapper;
using Dialysis.Common;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class FoodNutritionService
    {
        public readonly SystemRepository _systemRepository;
        public readonly FoodNutritionRepository _repository;
        public readonly IUnitWork _unitWork;

        public FoodNutritionService(SystemRepository systemRepository, FoodNutritionRepository repository, IUnitWork unitWork)
        {
            _unitWork = unitWork;
            _repository = repository;
            _systemRepository = systemRepository;
        }

        /// <summary>
        /// 获取食物类别列表
        /// </summary>
        /// <returns>食物类别列表</returns>
        public async Task<WebApiOutput<List<DictionaryDto>>> GetFoodTypeList()
        {
            var foodTypeList = await _systemRepository.GetDictionaryListByParentValue(CommConstant.FoodNutritionParentValue);

            return WebApiOutput<List<DictionaryDto>>.Success(Mapper.Map<List<Dictionary>, List<DictionaryDto>>(foodTypeList));
        }

        /// <summary>
        /// 获取食物详情
        /// </summary>
        /// <param name="foodId">食物Id</param>
        /// <returns>食物详情</returns>
        public async Task<WebApiOutput<FoodNutritionDto>> GetFoodNutritionById(int foodId)
        {
            var food = await _repository.GetFoodNutritionById(foodId);

            return WebApiOutput<FoodNutritionDto>.Success(Mapper.Map<FoodNutrition, FoodNutritionDto>(food));
        }

        /// <summary>
        /// 根据搜索分页获取食物列表
        /// </summary>
        /// <param name="input">搜索输入</param>
        /// <returns>食物列表</returns>
        public async Task<WebApiOutput<List<FoodNutritionDto>>> GetFoodNutritionPageList(FoodSearchInput input)
        {
            var foodList = await _repository.GetFoodNutritionPageList(input);

            return WebApiOutput<List<FoodNutritionDto>>.Success(Mapper.Map<List<FoodNutrition>, List<FoodNutritionDto>>(foodList));
        }
    }
}
