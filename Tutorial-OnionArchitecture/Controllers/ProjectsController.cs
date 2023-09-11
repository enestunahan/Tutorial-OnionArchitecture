using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial_OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> _projectList;
        private ILogger<ProjectsController> _logger;    
        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _projectList = new List<Project>
            {
                new Project{Id = Guid.NewGuid() , Name = "Project 1"},
                new Project{Id = Guid.NewGuid() , Name = "Project 2"},
                new Project{Id = Guid.NewGuid() , Name = "Project 3"}
            };
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;  

                _logger.LogInformation("Project.Get() has been run.");
                return Ok(_projectList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Project.Get() has been crashed"+ ex.Message);
                throw;
            }
          
        }
    }
}
