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
    public class HospitalService
    {
        public readonly HospitalRepository _repository;
        public readonly IUnitWork _unitWork;

        public HospitalService(HospitalRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 获取所有省份列表
        /// </summary>
        /// <returns>省份列表</returns>
        public async Task<List<AdminProvinceDto>> GetProvinceList()
        {
            var provinceList = await _repository.GetProvinceList();

            return Mapper.Map<List<Province>, List<AdminProvinceDto>>(provinceList);
        }

        /// <summary>
        /// 根据省份Id获取城市列表
        /// </summary>
        /// <param name="provinceId">省份Id</param>
        /// <returns>城市列表</returns>
        public async Task<List<AdminCityDto>> GetCityListByProvinceId(int provinceId)
        {
            var cityList = await _repository.GetCityListByProvinceId(provinceId);

            return Mapper.Map<List<City>, List<AdminCityDto>>(cityList);
        }

        /// <summary>
        /// 根据医院Id获取医院
        /// </summary>
        /// <param name="id">医院Id</param>
        /// <returns>医院</returns>
        public async Task<AdminHospitalDto> GetHospitalById(long id)
        {
            var hospital = await _repository.GetHospitalById(id);

            return Mapper.Map<Hospital, AdminHospitalDto>(hospital);
        }

        /// <summary>
        /// 新增医院
        /// </summary>
        /// <param name="model">医院信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Add(AdminHospitalDto model)
        {
            if (await _repository.GetHospitalByName(model.HospitalName) != null)
                return OutputBase.Fail("同名医院已存在");

            var entity = new Hospital
            {
                CityId = model.CityId,
                HospitalName = model.HospitalName
            };
            _repository.Add(entity);

            return _unitWork.Commit() ? OutputBase.Success("新增成功") : OutputBase.Fail("新增失败");
        }

        /// <summary>
        /// 删除医院
        /// </summary>
        /// <param name="id">医院Id</param>
        /// <returns>是否成功</returns>
        public OutputBase Delete(long id)
        {
            //if (await _repository.GetHospitalById(id) == null)
            //    return OutputBase.Fail("该医院已删除");
            _repository.Delete(id);

            return _unitWork.Commit() ? OutputBase.Success("删除成功") : OutputBase.Fail("删除失败");
        }

        /// <summary>
        /// 更新医院
        /// </summary>
        /// <param name="model">医院信息</param>
        /// <returns>是否成功</returns>
        public async Task<OutputBase> Update(AdminHospitalDto model)
        {
            var hospital = await _repository.GetHospitalById(model.Id);
            if (hospital == null)
                return OutputBase.Fail("该医院不存在");
            if (model.HospitalName != hospital.HospitalName && await _repository.GetHospitalByName(model.HospitalName) != null)
                return OutputBase.Fail("同名医院已存在");
            var entity = new Hospital
            {
                Id = model.Id,
                CityId = model.CityId,
                HospitalName = model.HospitalName
            };
            await _repository.Update(entity);

            return _unitWork.Commit() ? OutputBase.Success("更新成功") : OutputBase.Fail("更新失败");
        }

        /// <summary>
        /// 根据医院搜索输入分页获取医院列表
        /// </summary>
        /// <param name="input">医院搜索输入</param>
        /// <returns>医院列表</returns>
        public async Task<Tuple<List<HospitalViewDto>, int>> GetHospitalPageList(HospitalSearchInput input)
        {
            var result = await _repository.GetHospitalPageList(input);

            var tuple = new Tuple<List<HospitalViewDto>, int>(Mapper.Map<List<Hospital>, List<HospitalViewDto>>(result.Item1), result.Item2);

            return tuple;
        }

        /// <summary>
        /// 获取所有医院
        /// </summary>
        /// <returns>医院信息列表</returns>
        public async Task<List<DictDto>> GetHospitalList()
        {
            var hospitalList = await _repository.GetHospitalList();

            return Mapper.Map<List<Hospital>,List<DictDto>>(hospitalList);
        }
    }
}
