using HRM.Core.Interfaces;

namespace HRM.Core.Entities
{
    public class JobApplication : BaseEntity, IAuditable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public long StatusId { get; set; }  

        public virtual Status? Status { get; set; }      
        
        public long DepartmentId { get; set; }

        public virtual Department? Department { get; set; }

        public bool IsTestWork { get; set; }

        public IList<JobApplication> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
