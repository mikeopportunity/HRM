using HRM.Core.Entities;
using HRM.Domain.Model;
using HRM.Service.Interfaces;

namespace HRM.Service.Services
{
    public class DownloadService : IDownloadService
    {
        public DownloadService () { }
               
        public async Task<IList<JobApplication>> DownloadJobApplicationAsync(SearchRequest search)
        {
            var result = new List<JobApplication>();
            return result;
        }
    }
}
