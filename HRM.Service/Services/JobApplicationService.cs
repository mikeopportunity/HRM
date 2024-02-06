using Ardalis.Specification;
using HRM.Core.Entities;
using HRM.Core.Interfaces;
using HRM.Domain;
using HRM.Domain.Model;
using HRM.Service.Interfaces;
using HRM.Service.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IEfRepository<JobApplication> _jobApplicationRepository;
        private readonly IDownloadService _downloadService;

        public JobApplicationService(IEfRepository<JobApplication> jobApplicationRepository, IDownloadService downloadService) 
        {
            _jobApplicationRepository = jobApplicationRepository;
            _downloadService = downloadService;
        }

        public async Task<DataResult<IList<JobApplication>>> UploadJobApplicationAsync(SearchRequest searchRequest)
        {
            var jobApplications = await _downloadService.DownloadJobApplicationAsync(searchRequest);
            
            var result = await _jobApplicationRepository.AddRangeAsync(jobApplications);

            if (result.Any())
                return new DataResult<IList<JobApplication>>()
                {
                    Success = true,
                    Data = result.ToList()
                };

            return new DataResult<IList<JobApplication>>()
            {
                Message = "Ошибка: Не удалось получить или сохранить резюме по данным параметрам"
            };                      
        }

        public async Task<DataResult<IList<JobApplication>>> SearchJobApplicationAsync(JobApplicationRequest jobApplicationRequest)
        {
            var result = await _jobApplicationRepository.ListAsync(SetSearch(jobApplicationRequest.Search, jobApplicationRequest.IsFullSearch));

            return new DataResult<IList<JobApplication>>()
            {
                Success = true,
                Data = result.ToList()
            };
        }

        public async Task<DataResult<JobApplication>> UpdateStatus(long jobApplicationId, long statusId, bool isTestWork = false)
        {
            var jobAplication = await _jobApplicationRepository.GetByIdAsync(jobApplicationId);
            jobAplication.StatusId = statusId;
            jobAplication.IsTestWork = jobAplication.IsTestWork ? true : isTestWork;
            await _jobApplicationRepository.SaveChangesAsync();

            return new DataResult<JobApplication>()
            {
                Success = true,
                Data = jobAplication
            };
        }

        public async Task<DataResult<IList<JobApplication>>> GetAsync()
        {
            var jobApplications = await _jobApplicationRepository.ListAsync();

            return new DataResult<IList<JobApplication>>()
            {
                Success = true,
                Data = jobApplications
            };
        }

        public async Task<DataResult<JobApplication>> SaveAsync(JobApplication jobApplication)
        {
            var result = await _jobApplicationRepository.AddAsync(jobApplication);
            return new DataResult<JobApplication>()
            {
                Success = true,
                Data = result
            };
        }

        private ISpecification<JobApplication> SetSearch(string search, bool isFullSearch = false)
        {
            if (isFullSearch)
                return new JobApplicationSearchByFulltextSpecification(search);
            
            return  new JobApplicationSearchByFulltextSpecification(search);
        }

        
    }
}
