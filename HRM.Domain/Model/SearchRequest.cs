
namespace HRM.Domain.Model
{
    public class SearchRequest
    {
        public string Url { get; set; }

        public string? Tags { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
