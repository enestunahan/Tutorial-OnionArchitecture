using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Tutorial_OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> _projectList;
        private ILoggerManager _loggerManager;
        private readonly IRepositoryManager _repositoryManager;

        public ProjectsController(ILoggerManager loggerManager, IRepositoryManager repositoryManager )
        {
            _projectList = new List<Project>
            {
                new Project{Id = Guid.NewGuid() , Name = "Project 1"},
                new Project{Id = Guid.NewGuid() , Name = "Project 2"},
                new Project{Id = Guid.NewGuid() , Name = "Project 3"}
            };
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _loggerManager.LogInfo("Project.Get() has been run.");
                var projectList = _repositoryManager.Project.GetAllProjects(false);
                return Ok(projectList);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("Project.Get() has been crashed"+ ex.Message);
                throw;
            }
          
        }
    }
}
