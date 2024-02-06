using Ardalis.Specification;
using HRM.Core.Entities;
using HRM.Domain.Model;

namespace HRM.Service.Specifications
{
    public sealed class AuditSpecification : Specification<Audit>
    {
        public AuditSpecification(ReportRequest reportRequest)
        {
            Query.Where(a => (a.ChangeId == reportRequest.UserId &&
                (a.ChangeDate >= reportRequest.CreateDate && a.ChangeDate <= reportRequest.EndDate)));
        }
    }
}
