
using HRM.Core.Entities;
using HRM.Domain;
using HRM.Domain.Model;
using System.Numerics;

namespace HRM.Service.Interfaces
{
    public interface IJobApplicationService
    {
        /// <summary>
        /// Сохраняем вакансии в БД
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        Task<DataResult<IList<JobApplication>>> UploadJobApplicationAsync(SearchRequest searchRequest);

        /// <summary>
        /// Поиск по скачанным вакансиям в БД 
        /// </summary>
        /// <param name="search">параметры поиска</param>
        /// <param name="isFullSearch">признак где ищем только в наименовании или по полям: Name, Description и Tags</param>
        /// <returns></returns>
        Task<DataResult<IList<JobApplication>>> SearchJobApplicationAsync(JobApplicationRequest jobApplicationRequest);

        /// <summary>
        /// Обновляем статус резюме в БД
        /// </summary>
        /// <param name="jobApplicationId"></param>
        /// <param name="statusId"></param>
        /// <param name="isTestWork"></param>
        /// <returns></returns>
        Task<DataResult<JobApplication>> UpdateStatus(long jobApplicationId, long statusId, bool isTestWork = false);


        /// <summary>
        /// Получение списка всех резюме
        /// </summary>
        /// <returns></returns>
        Task<DataResult<IList<JobApplication>>> GetAsync();

        /// <summary>
        /// Добавление резюме
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <returns></returns>
        Task<DataResult<JobApplication>> SaveAsync(JobApplication jobApplication);

    }
}
