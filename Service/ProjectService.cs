using AutoMapper;
using Contracts;
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
            try
            {
                var projects = _repositoryManager.Project.GetAllProjects(trackChanges);
                var result = _mapper.Map<IEnumerable<ProjectDto>>(projects);
                return result;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ProjectService.GetAllProjects() has an error" + ex.Message);
                throw;
            }   
        }

        public ProjectDto GetProjectById(Guid id)
        {
            try
            {
                var project = _repositoryManager.Project.GetProject(id, false);
                var projectDto = _mapper.Map<ProjectDto>(project);
                return projectDto;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("ProjectService.GetProjectById() has an error" + ex.Message);
                throw;
            }
        }
    }
}
