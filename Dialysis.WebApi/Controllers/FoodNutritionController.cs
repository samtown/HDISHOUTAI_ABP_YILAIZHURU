using Dialysis.Dto.WebApi;
using Dialysis.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.WebApi.Controllers
{
    /// <summary>
    /// 食物速查
    /// </summary>
    [Produces("application/json")]
    [Route("api/FoodSearch")]
    public class FoodNutritionController : Controller
    {
        private readonly FoodNutritionService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public FoodNutritionController(FoodNutritionService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取食物类别列表
        /// </summary>
        /// <returns>食物类别列表</returns>
        [HttpGet("FoodType")]
        public async Task<WebApiOutput<List<DictionaryDto>>> GetFoodTypeList()
        {
            return await _service.GetFoodTypeList();
        }

        /// <summary>
        /// 获取食物详情
        /// </summary>
        /// <param name="foodId">食物Id</param>
        /// <returns>食物详情</returns>
        [HttpGet("{foodId}")]
        public async Task<WebApiOutput<FoodNutritionDto>> GetFoodNutritionById(int foodId)
        {
            return await _service.GetFoodNutritionById(foodId);
        }

        /// <summary>
        /// 根据搜索分页获取食物列表
        /// </summary>
        /// <param name="input">搜索输入</param>
        /// <returns>食物列表</returns>
        [HttpGet("{foodType}/{pageIndex}/{pageSize}/{foodName?}")]
        public async Task<WebApiOutput<List<FoodNutritionDto>>> GetFoodNutritionPageList(FoodSearchInput input)
        {
            return await _service.GetFoodNutritionPageList(input);
        }
    }
}