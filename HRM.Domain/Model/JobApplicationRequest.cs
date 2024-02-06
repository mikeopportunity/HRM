
namespace HRM.Domain.Model
{
    public class JobApplicationRequest
    {
        public string Search {  get; set; }
        public bool IsFullSearch { get; set; } = false;
    }
}
