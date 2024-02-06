using Ardalis.Specification;

namespace HRM.Core.Interfaces
{
    public interface IEfRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
