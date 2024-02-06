namespace HRM.Core.Entities
{
    public class Employeer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public long DepartmentId {  get; set; }
        public virtual Department Department { get; set; }  
    }
}
