using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManager repositoryManager, ILoggerManager loggerManager , IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<ProjectDto> GetAllProjects(bool trackChanges)
        {          
            var projects = _repositoryManager.Project.GetAllProjects(trackChanges);
            var result = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return result;                      
        }

        public ProjectDto GetProjectById(Guid id)
        {          
           var project = _repositoryManager.Project.GetProject(id, false);
           if(project == null)
            {
                throw new ProjectNotFoundExceptions(id);
            }
           var projectDto = _mapper.Map<ProjectDto>(project);
           return projectDto;    
        }
    }
}
