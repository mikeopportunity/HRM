using HRM.Core.Entities;
using HRM.Domain.Model;
using HRM.Service.Interfaces;
using HRM.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private IJobApplicationService _jobApplicationService;

        public JobApplicationController(IJobApplicationService jobApplicationService) 
        {
            _jobApplicationService = jobApplicationService;
        }   

        /// <summary>
        /// Сохраняем резюме в БД
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobApplication jobApplication)
        {
            var result = await _jobApplicationService.SaveAsync(jobApplication);
            return Ok(result);
        }

        /// <summary>
        /// Обновление статуса резюме
        /// </summary>
        /// <param name="updateJobStatusRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Post([FromBody] UpdateJobStatusRequest updateJobStatusRequest)
        {
            var result = await _jobApplicationService.UpdateStatus(updateJobStatusRequest.JobApplicationId, updateJobStatusRequest.StatusId, updateJobStatusRequest.IsTestWork);
            return Ok(result);
        }

        /// <summary>
        /// Поиск резюме по БД
        /// </summary>
        /// <param name="jobApplicationRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Post([FromBody] JobApplicationRequest jobApplicationRequest)
        {
            var result = await _jobApplicationService.SearchJobApplicationAsync(jobApplicationRequest);
            return Ok(result);
        }

        /// <summary>
        /// Поиск и загрузка резюме в БД из внешнего источника 
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("search/source")]
        public async Task<IActionResult> Post([FromBody] SearchRequest searchRequest)
        {
            var result = await _jobApplicationService.UploadJobApplicationAsync(searchRequest);
            return Ok(result);
        }

       
    }
}
