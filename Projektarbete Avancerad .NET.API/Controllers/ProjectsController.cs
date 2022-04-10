using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projektarbete_Avancerad_.NET.API.Services;
using Projektarbete_Avancerad_.NET.Models;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IpaANET<Project> _projectRepo;
        public ProjectsController(IpaANET<Project> projectRepo)
        {
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                return Ok(await _projectRepo.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var result = await _projectRepo.GetSingle(id);
                if (result == null)
                {
                    return NotFound($"Project with ID: {id} was not found in database");
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
        public async Task<ActionResult<Project>> CreateProject(Project newProject)
        {
            try
            {
                if (newProject == null)
                {
                    return BadRequest("New project could not be created");
                }
                var createdProject = await _projectRepo.Add(newProject);
                return CreatedAtAction(nameof(CreateProject), new { id = createdProject.ProjectID }, createdProject);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to create new project");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Project>> updateProject(int id, Project project)
        {
            try
            {
                if (id != project.ProjectID)
                {
                    return BadRequest($"Project with ID: {id} could not be updated");
                }
                var updatedProject = await _projectRepo.GetSingle(id);
                if (updatedProject == null)
                {
                    return NotFound($"Project with ID: {id} was not found");
                }
                return await _projectRepo.Update(project);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to update project");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var projectToDel = await _projectRepo.GetSingle(id);
                if (projectToDel == null)
                {
                    return NotFound($"Project with ID: {id} was not found");
                }
                return await _projectRepo.Delete(id);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to delete project");
            }
        }
    }
}
