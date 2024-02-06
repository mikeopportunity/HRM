using HRM.Core.Entities;
using HRM.Core.Interfaces;
using HRM.Domain;
using HRM.Domain.Model;
using HRM.Service.Interfaces;
using HRM.Service.Specifications;

namespace HRM.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IEfRepository<Audit> _auditRepository;
       
        public ReportService(IEfRepository<Audit> auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public async Task<DataResult<ReportResponse>> CreateReportAsync(ReportRequest reportRequest)
        {
            var spec = new AuditSpecification(reportRequest);
            var listAudits = await _auditRepository.ListAsync(spec);

            return new DataResult<ReportResponse>()
            {
                Success = true,
                Data = MapAuditToResponseItem(listAudits)
            };
        }

        /// <summary>
        /// Использовать IAutoMapper и через него делать маппинг между моделями 
        /// </summary>
        /// <param name="audits"></param>
        /// <returns></returns>
        private ReportResponse MapAuditToResponseItem(IList<Audit> audits)
        {
            var reportResponse = new ReportResponse();

            foreach (var audit in audits)
            {
                reportResponse.ReportItems.Add(new ReportItemResponse()
                {
                    //маппинг
                });
            }

            return reportResponse;
        }
    }
}
