using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projektarbete_Avancerad_.NET.API.Services;
using Projektarbete_Avancerad_.NET.Models;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IpaANET<Employee> _empRepo;

        public EmployeesController(IpaANET<Employee> empRepo)
        {
            _empRepo = empRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _empRepo.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _empRepo.GetSingle(id);
                if (result == null)
                {
                    return NotFound($"Employee with ID: {id} was not found in database");
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
        public async Task<ActionResult<Employee>> CreateEmployee(Employee newEmployee)
        {
            try
            {
                if (newEmployee == null)
                {
                    return BadRequest("New employee could not be created");
                }
                var createdEmp = await _empRepo.Add(newEmployee);
                return CreatedAtAction(nameof(CreateEmployee), new { id = createdEmp.EmployeeID }, createdEmp);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to create new employee");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> updateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeID)
                {
                    return BadRequest($"Employee with ID: {id} could not be updated");
                }
                var updatedEmp = await _empRepo.GetSingle(id);
                if (updatedEmp == null)
                {
                    return NotFound($"Employee with ID: {id} was not found");
                }
                return await _empRepo.Update(employee);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to update employee");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var empToDel = await _empRepo.GetSingle(id);
                if (empToDel == null)
                {
                    return NotFound($"Employee with ID: {id} was not found");
                }
                return await _empRepo.Delete(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to delete employee");
            }
        }


    }
}
