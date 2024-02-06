using HRM.Core.Entities;
using HRM.Domain.Model;

namespace HRM.Service.Interfaces
{
    public interface IDownloadService
    {
        /// <summary>
        /// Получаем список вакансий с определенного сайта по определенным условиям поиска
        /// (плюс необходим маппинг на IList<JobApplication>)
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<IList<JobApplication>> DownloadJobApplicationAsync(SearchRequest search);
    }
}
