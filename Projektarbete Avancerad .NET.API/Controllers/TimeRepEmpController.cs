using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projektarbete_Avancerad_.NET.API.Services;
using Projektarbete_Avancerad_.NET.Models;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRepEmpController : ControllerBase
    {
        private IpaANET<TimeRepEmployee> _timeRepEmpRepo;
        public TimeRepEmpController(IpaANET<TimeRepEmployee> timeRepEmpRepo)
        {
            _timeRepEmpRepo = timeRepEmpRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeReports()
        {
            try
            {
                return Ok(await _timeRepEmpRepo.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeRepEmployee>> GetEmployee(int id)
        {
            try
            {
                var result = await _timeRepEmpRepo.GetSingle(id);
                if (result == null)
                {
                    return NotFound($"TimeRepEmp with ID: {id} was not found in database");
                }
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeRepEmployee>> CreateTimeRepEmp(TimeRepEmployee timeRepEmp)
        {
            try
            {
                if (timeRepEmp == null)
                {
                    return BadRequest("New TimeRepEmp could not be created");
                }
                var createdTimeRepEmp = await _timeRepEmpRepo.Add(timeRepEmp);
                return CreatedAtAction(nameof(CreateTimeRepEmp), new { id = createdTimeRepEmp.TimeReportID }, createdTimeRepEmp);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to create new TimeRepEmp");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TimeRepEmployee>> updateTimeRepEmp(int id, TimeRepEmployee timeRepEmp)
        {
            try
            {
                if (id != timeRepEmp.TimeRepEmployeeID)
                {
                    return BadRequest($"TimeRepEmp with ID: {id} could not be updated");
                }
                var updatedTimeRepEmp = await _timeRepEmpRepo.GetSingle(id);
                if (updatedTimeRepEmp == null)
                {
                    return NotFound($"Time report with ID: {id} was not found");
                }
                return await _timeRepEmpRepo.Update(timeRepEmp);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to update TimeRepEmp");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeRepEmployee>> DeleteTimeRepEmp(int id)
        {
            try
            {
                var timeRepEmpToDel = await _timeRepEmpRepo.GetSingle(id);
                if (timeRepEmpToDel == null)
                {
                    return NotFound($"Time report with ID: {id} was not found");
                }
                return await _timeRepEmpRepo.Delete(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to delete TimeRepEmp");
            }
        }



    }
}
