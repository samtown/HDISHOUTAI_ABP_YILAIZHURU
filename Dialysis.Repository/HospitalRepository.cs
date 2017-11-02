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
    public class HospitalRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public HospitalRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 新增医院
        /// </summary>
        /// <param name="entity">医院实体</param>
        public void Add(Hospital entity)
        {
            entity.Id = _idGenerator.CreateId();

            _context.Hospital.Add(entity);
        }

        /// <summary>
        /// 删除医院
        /// </summary>
        /// <param name="id">医院Id</param>
        public void Delete(long id)
        {
            _context.Hospital.Remove(new Hospital { Id = id });
        }

        /// <summary>
        /// 更新医院
        /// </summary>
        /// <param name="entity">医院实体</param>
        public async Task Update(Hospital entity)
        {
            var hospital = await _context.Hospital.FindAsync(entity.Id);
            hospital.CityId = entity.CityId;
            hospital.HospitalName = entity.HospitalName;
        }

        /// <summary>
        /// 根据医院Id获取医院实体
        /// </summary>
        /// <param name="id">医院Id</param>
        /// <returns>医院实体</returns>
        public async Task<Hospital> GetHospitalById(long id)
        {
            var hospital = await _context.Hospital.Include(i => i.City).Where(i => i.Id == id).FirstOrDefaultAsync();

            return hospital;
        }

        /// <summary>
        /// 根据医院名称获取医院实体
        /// </summary>
        /// <param name="name">医院名称</param>
        /// <returns>医院实体</returns>
        public async Task<Hospital> GetHospitalByName(string name)
        {
            var hospital = await _context.Hospital.Where(i => i.HospitalName == name).FirstOrDefaultAsync();

            return hospital;
        }

        /// <summary>
        /// 获取所有医院实体列表
        /// </summary>
        /// <returns>医院实体列表</returns>
        public async Task<List<Hospital>> GetHospitalList()
        {
            var hospitalList = await _context.Hospital.ToListAsync();

            return hospitalList;
        }

        /// <summary>
        /// 根据医院搜索输入分页获取医院实体列表
        /// </summary>
        /// <param name="input">医院搜索输入</param>
        /// <returns>医院实体列表</returns>
        public async Task<Tuple<List<Hospital>, int>> GetHospitalPageList(HospitalSearchInput input)
        {
            var query = _context.Hospital.Include(i => i.City.Province).AsQueryable();

            if (!string.IsNullOrEmpty(input.HospitalName))
            {
                query = query.Where(i => i.HospitalName.Contains(input.HospitalName));
            }
            if (input.CityId != -1)
            {
                query = query.Where(i => i.CityId == input.CityId);
            }

            int total = query.Count();
            var hospitalList = await query.OrderBy(i => i.Id).Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize).ToListAsync();

            return new Tuple<List<Hospital>, int>(hospitalList, total);
        }

        /// <summary>
        /// 获取所有省份实体列表
        /// </summary>
        /// <returns>省份实体列表</returns>
        public async Task<List<Province>> GetProvinceList()
        {
            var provinceList = await _context.Province.ToListAsync();

            return provinceList;
        }

        /// <summary>
        /// 根据省份Id获取城市实体列表
        /// </summary>
        /// <param name="provinceId">省份Id</param>
        /// <returns>城市实体列表</returns>
        public async Task<List<City>> GetCityListByProvinceId(int provinceId)
        {
            var cityList = await _context.City.Where(i => i.ProvinceId == provinceId).ToListAsync();

            return cityList;
        }
    }
}
