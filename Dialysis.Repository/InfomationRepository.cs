using Dialysis.Domain;
using Dialysis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class InfomationRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;

        public InfomationRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
        }

        /// <summary>
        /// 根据资讯Id获取资讯实体
        /// </summary>
        /// <param name="id">资讯Id</param>
        /// <returns>资讯实体</returns>
        public async Task<Infomation> GetInfomationById(long id)
        {
            var infomation = await _context.Infomation.FindAsync(id);

            return infomation;
        }

        /// <summary>
        /// 获取首页轮播资讯实体列表
        /// </summary>
        /// <returns>首页轮播资讯实体列表</returns>
        public async Task<List<Infomation>> GetHomePageSlideInfomationList()
        {
            var infomationList = await _context.Infomation.Where(i => i.IsHomePageSlide).ToListAsync();

            return infomationList;
        }
    }
}
