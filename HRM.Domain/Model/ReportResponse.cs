
namespace HRM.Domain.Model
{
    public class ReportResponse
    {
        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public IList<ReportItemResponse> ReportItems { get; set; } = new List<ReportItemResponse>();
    }
}
