using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial_OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> _projectList;
        private ILoggerManager _loggerManager;

        public ProjectsController(ILoggerManager loggerManager)
        {
            _projectList = new List<Project>
            {
                new Project{Id = Guid.NewGuid() , Name = "Project 1"},
                new Project{Id = Guid.NewGuid() , Name = "Project 2"},
                new Project{Id = Guid.NewGuid() , Name = "Project 3"}
            };
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;

                _loggerManager.LogInfo("Project.Get() has been run.");
                return Ok(_projectList);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("Project.Get() has been crashed"+ ex.Message);
                throw;
            }
          
        }
    }
}
