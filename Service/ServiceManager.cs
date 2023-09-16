using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProjectService _projectService;
        public ServiceManager(IRepositoryManager repositoryManager , ILoggerManager loggerManager)
        {
            _projectService = new ProjectService(repositoryManager, loggerManager);
        }
        public IProjectService ProjectService => _projectService;
    }
}
