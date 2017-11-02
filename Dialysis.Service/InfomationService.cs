using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class InfomationService
    {
        public readonly InfomationRepository _repository;
        public readonly IUnitWork _unitWork;

        public InfomationService(InfomationRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 根据资讯Id获取资讯详情
        /// </summary>
        /// <param name="infomationId">资讯Id</param>
        /// <returns>资讯详情</returns>
        public async Task<WebApiOutput<InfomationDto>> GetInfomationById(long infomationId)
        {
            var infomation = await _repository.GetInfomationById(infomationId);

            return WebApiOutput<InfomationDto>.Success(Mapper.Map<Infomation, InfomationDto>(infomation));
        }

        /// <summary>
        /// 获取首页轮播资讯
        /// </summary>
        /// <returns>首页轮播资讯列表</returns>
        public async Task<WebApiOutput<List<InfomationDto>>> GetHomePageSlideInfomationList()
        {
            var infomationList = await _repository.GetHomePageSlideInfomationList();

            return WebApiOutput<List<InfomationDto>>.Success(Mapper.Map<List<Infomation>, List<InfomationDto>>(infomationList));
        }
    }
}
