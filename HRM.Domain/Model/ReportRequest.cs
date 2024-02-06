namespace HRM.Domain.Model
{
    public class ReportRequest
    {
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? UserId { get; set; } = 0;
        public long? StatusId { get; set; } = 0;
        public long? DepartmentId { get; set; } = 0; 
    }
}
