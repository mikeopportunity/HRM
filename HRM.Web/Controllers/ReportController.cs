using HRM.Domain.Model;
using HRM.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService) 
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Формирование отчета по менеджерам
        /// </summary>
        /// <param name="reportRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("generate")]
        public async Task<IActionResult> Post([FromBody] ReportRequest reportRequest)
        {
            var result = await _reportService.CreateReportAsync(reportRequest);
            return Ok(result);
        }

    }
}
