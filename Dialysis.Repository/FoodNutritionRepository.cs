using Dialysis.Domain;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class FoodNutritionRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;

        public FoodNutritionRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 根据食物Id获取食物实体
        /// </summary>
        /// <param name="id">食物Id</param>
        /// <returns>食物实体</returns>
        public async Task<FoodNutrition> GetFoodNutritionById(int id)
        {
            var food = await _context.FoodNutrition.FindAsync(id);

            return food;
        }

        /// <summary>
        /// 根据食物搜索输入分页获取食物实体列表
        /// </summary>
        /// <param name="input">食物搜索输入</param>
        /// <returns>食物实体列表</returns>
        public async Task<List<FoodNutrition>> GetFoodNutritionPageList(FoodSearchInput input)
        {
            var query = _context.FoodNutrition.AsQueryable();

            query = query.Where(i => i.FoodType == input.FoodType);
            if (!string.IsNullOrEmpty(input.FoodName))
            {
                query = query.Where(i => i.FoodName.Contains(input.FoodName));
            }

            var foodList = await query.OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return foodList;
        }
    }
}
