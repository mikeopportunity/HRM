namespace HRM.Core.Entities
{
    public class Audit
    {
        public long Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public long ChangeId { get; set; }
        public String ChangeUserName { get; set; }
        public String TableName { get; set; }
        public String? Action { get; set; }
        public String? KeyValues { get; set; }
        public String? OldValues { get; set; }
        public String? NewValues { get; set; }
    }
}
