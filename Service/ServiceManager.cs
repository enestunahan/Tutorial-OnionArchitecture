using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProjectService> _projectService;
        public ServiceManager(IRepositoryManager repositoryManager , ILoggerManager loggerManager)
        {
            _projectService = new Lazy<IProjectService>( () =>  new ProjectService(repositoryManager, loggerManager));
        }
        public IProjectService ProjectService => _projectService.Value;
    }
}
