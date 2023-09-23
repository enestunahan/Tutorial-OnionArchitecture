using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ProjectService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public IEnumerable<Project> GetAllProjects(bool trackChanges)
        {
            try
            {
                var projects = _repositoryManager.Project.GetAllProjects(trackChanges);
                return projects;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ProjectService.GetAllProjects() has an error" + ex.Message);
                throw;
            }
        
        }

        public Project GetProjectById(Guid id)
        {
            try
            {
                var project = _repositoryManager.Project.GetProject(id, false);
                return project;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ProjectService.GetProjectById() has an error" + ex.Message);
                throw;
            }
        }
    }
}
