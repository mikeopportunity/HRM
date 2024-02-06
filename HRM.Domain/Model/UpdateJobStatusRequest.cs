
namespace HRM.Domain.Model
{
    public class UpdateJobStatusRequest
    {
        public long JobApplicationId { get; set; }
        public long StatusId { get; set;}
        public bool IsTestWork { get; set; } = false;
    }
}
