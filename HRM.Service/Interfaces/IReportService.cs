using HRM.Domain.Model;
using HRM.Domain;

namespace HRM.Service.Interfaces
{
    public interface IReportService
    {
        /// <summary>
        /// Метод формирование отчетов по менеджерам в разрезе дат
        /// </summary>
        /// <param name="reportRequest"></param>
        /// <returns></returns>
        Task<DataResult<ReportResponse>> CreateReportAsync(ReportRequest reportRequest);
    }
}
