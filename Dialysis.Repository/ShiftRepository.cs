using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dialysis.Repository
{
    public class ShiftRepository
    {
        private readonly DialysisContext _context;
        private readonly MyOptions _optionsAccessor;
        private readonly Flakey.IdGenerator _idGenerator;

        public ShiftRepository(DialysisContext context, IOptions<MyOptions> optionsAccessor)
        {
            _context = context;
            _optionsAccessor = optionsAccessor.Value;
            _idGenerator = IdGenerator.CreateGenerator(_optionsAccessor.GeneratorId);
        }

        /// <summary>
        /// 获取排班
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<List<Shift>> Get(long hospitalId)
        {
            return await _context.Shift.Where(t => t.HospitalId == hospitalId).ToListAsync();
        }

        /// <summary>
        /// 获取排班
        /// </summary>
        /// <param name="dialysisShiftId">透析班次Id（华墨系统Id）</param>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        public async Task<Shift> Get(int dialysisShiftId, long hospitalId)
        {
            return await _context.Shift.SingleOrDefaultAsync(t => t.DialysisShiftId == dialysisShiftId && t.HospitalId == hospitalId);
        }

        /// <summary>
        /// 新增排班
        /// </summary>
        /// <param name="shift">排班</param>
        /// <returns></returns>
        public void Add(Shift shift)
        {
            shift.Id = _idGenerator.CreateId();
            _context.Shift.Add(shift);
        }
    }
}
