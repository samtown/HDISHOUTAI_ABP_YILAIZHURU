using Dialysis.Dto.WebApi;
using Dialysis.H5.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.H5.Controllers
{
    public class FoodNutrtionController : Controller
    {
        private readonly MyOptions _optionsAccessor;

        public FoodNutrtionController(IOptions<MyOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 食物速查类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TypeList()
        {
            var request = new RestRequest();
            request.Resource = "/api/FoodSearch/FoodType";

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<List<DictionaryDto>>>(request);
            if (response.IsSuccess && response.ResultValue != null && response.ResultValue.Count > 0)
            {
                return View(response.ResultValue);
            }

            return View(new List<DictionaryDto>());
        }

        /// <summary>
        /// 根据类型获取食物列表
        /// </summary>
        /// <param name="foodType">类型</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FoodList(int foodType)
        {
            //int total = 0;
            var request = new RestRequest();
            request.Resource = "/api/FoodSearch/{foodType}/{pageIndex}/{pageSize}/{foodName}";
            request.AddParameter("foodName", string.Empty, ParameterType.UrlSegment);
            request.AddParameter("foodType", foodType, ParameterType.UrlSegment);
            request.AddParameter("pageIndex", 1, ParameterType.UrlSegment);
            request.AddParameter("pageSize", 5, ParameterType.UrlSegment);
            //request.AddParameter("total", total, ParameterType.QueryString);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<List<FoodNutritionDto>>>(request);
            if (response.IsSuccess && response.ResultValue != null && response.ResultValue.Count > 0)
            {
                ViewBag.PageSize = 5;
                ViewBag.PageIndex = 1;
                ViewBag.CurrentPageTotal = response.ResultValue.Count;
                ViewBag.FoodType = foodType;
                return View(response.ResultValue);
            }
            return View(new List<FoodNutritionDto>());
        }

        /// <summary>
        /// 分页获取食物列表
        /// </summary>
        /// <param name="model">分页获取食物列表请求</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetFoodList(FoodSearchInput model)
        {
            //int total = 0;
            var request = new RestRequest();
            request.Resource = "/api/FoodSearch/{foodType}/{pageIndex}/{pageSize}/{foodName}";
            request.AddParameter("foodName", string.IsNullOrEmpty(model.FoodName) ? string.Empty : model.FoodName, ParameterType.UrlSegment);
            request.AddParameter("foodType", model.FoodType, ParameterType.UrlSegment);
            request.AddParameter("pageIndex", model.PageIndex, ParameterType.UrlSegment);
            request.AddParameter("pageSize", model.PageSize, ParameterType.UrlSegment);
            //request.AddParameter("total", total, ParameterType.QueryString);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<List<FoodNutritionDto>>>(request);
            if (response.IsSuccess && response.ResultValue != null && response.ResultValue.Count > 0)
            {
                return Json(new { ResultCode = "0", ResultValue = response.ResultValue });
            }
            return Json(new { ResultCode = "1", ResultValue = response.ResultValue });
        }

        /// <summary>
        /// 食物详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [StaticFileHandlerFilter(Key = "id")]
        [HttpGet]
        public async Task<IActionResult> FoodDetail(int id)
        {
            var request = new RestRequest();
            request.Resource = "/api/FoodSearch/{foodId}";
            request.AddParameter("foodId", id, ParameterType.UrlSegment);

            var api = new DialysisWebApi(_optionsAccessor.BaseUrl);
            var response = await api.ExecuteAsync<WebApiOutput<FoodNutritionDto>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return View(response.ResultValue);
            }
            return View(new FoodNutritionDto());
        }
    }
}