using Dialysis.Domain;

namespace Dialysis.Repository
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitWork : IUnitWork
    {
        private readonly DialysisContext _context;

        public UnitWork(DialysisContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            _context.SaveChanges();
            return true;
        }
    }
}
