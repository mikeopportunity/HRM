using Ardalis.Specification;
using HRM.Core.Entities;

namespace HRM.Service.Specifications
{
    public sealed class JobApplicationSearchByNameSpecification : Specification<JobApplication>
    {
        public JobApplicationSearchByNameSpecification(string name)
        {
            Query.Where(j => j.Name.Contains(name));
        }
    }
}
