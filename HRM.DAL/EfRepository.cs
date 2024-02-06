using Ardalis.Specification.EntityFrameworkCore;
using HRM.Core.Interfaces;

namespace HRM.DAL
{
    public class EfRepository<T> : RepositoryBase<T>, IEfRepository<T> where T : class
    {
        public EfRepository(HRMContext dbContext) : base(dbContext)
        {
        }
    }
}
