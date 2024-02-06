using Ardalis.Specification;
using HRM.Core.Entities;

namespace HRM.Service.Specifications
{
    public sealed class JobApplicationSearchByFulltextSpecification : Specification<JobApplication>
    {
        public JobApplicationSearchByFulltextSpecification(string search)
        {
            Query.Where(j => j.Name.Contains(search) || j.Description.Contains(search) || j.Tags.Contains(search));
        }
    }
}
