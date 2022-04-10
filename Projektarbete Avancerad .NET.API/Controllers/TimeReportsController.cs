using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projektarbete_Avancerad_.NET.API.Services;
using Projektarbete_Avancerad_.NET.Models;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        private IpaANET<TimeReport> _timeReportRepo;
        public TimeReportsController(IpaANET<TimeReport> timeReportRepo)
        {
            _timeReportRepo = timeReportRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeReports()
        {
            try
            {
                return Ok(await _timeReportRepo.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{week:int}")]
        public async Task<IActionResult> GetWeek(int week)
        {
            try
            {
                return Ok(await _timeReportRepo.GetAll(week));
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> CreateTimeReport(TimeReport timeReport)
        {
            try
            {
                if (timeReport == null)
                {
                    return BadRequest("New Time report could not be created");
                }
                var createdTimeReport = await _timeReportRepo.Add(timeReport);
                return CreatedAtAction(nameof(CreateTimeReport), new { id = createdTimeReport.TimeReportID }, createdTimeReport);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to create new Time report");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TimeReport>> updateTimeReport(int id, TimeReport timeReport)
        {
            try
            {
                if (id != timeReport.TimeReportID)
                {
                    return BadRequest($"Time report with ID: {id} could not be updated");
                }
                var updatedTimeReport = await _timeReportRepo.GetSingle(id);
                if (updatedTimeReport == null)
                {
                    return NotFound($"Time report with ID: {id} was not found");
                }
                return await _timeReportRepo.Update(timeReport);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to update time report");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var timeReportToDel = await _timeReportRepo.GetSingle(id);
                if (timeReportToDel == null)
                {
                    return NotFound($"Time report with ID: {id} was not found");
                }
                return await _timeReportRepo.Delete(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to delete time report");
            }
        }
    }
}
