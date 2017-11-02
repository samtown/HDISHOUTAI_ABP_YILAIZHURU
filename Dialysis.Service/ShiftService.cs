using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Common;
using Dialysis.Dto.WebApi;
using Dialysis.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dialysis.Service
{
    public class ShiftService
    {
        public readonly ShiftRepository _repository;
        public readonly IUnitWork _unitWork;

        public ShiftService(ShiftRepository repository, IUnitWork unitWork)
        {
            _repository = repository;
            _unitWork = unitWork;
        }

        /// <summary>
        /// 同步排班(新增或修改)
        /// </summary>
        /// <param name="sync"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddOrUpdate(AddShiftSync sync)
        {
            var shift = await _repository.Get(sync.DialysisShiftId, sync.HospitalId);
            if (shift == null)
            {
                _repository.Add(Mapper.Map<AddShiftSync, Shift>(sync));
            }
            else
            {
                Mapper.Map(sync, shift);
            }

            return _unitWork.Commit() ? OutputBase.Success("保存成功") : OutputBase.Fail("保存失败");
        }

        /// <summary>
        /// 获取医院排班信息
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<List<HospitalShiftDto>> Get(long hospitalId)
        {
            return Mapper.Map<List<Shift>, List<HospitalShiftDto>>(await _repository.Get(hospitalId));
        }
    }
}
