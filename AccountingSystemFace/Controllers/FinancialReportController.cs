using AccountingSystemAPI.Models;
using AccountingSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemFace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialReportController : ControllerBase
    {
        private readonly FinancialReportService _report;
        public FinancialReportController(FinancialReportService reportService)
        {
                _report = reportService;
        }

        [HttpGet]
        [Route("FinancialReport/{productId}")]
        public IActionResult GenerateReport(int productId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            FinancialReport report = _report.GenerateFinancialReport(productId, startDate, endDate);
            return Ok(report);
        }
    }
}
