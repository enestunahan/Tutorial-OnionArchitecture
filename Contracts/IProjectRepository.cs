using Entities.Models;

namespace Contracts
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects(bool trackChanges);
        Project GetProject(int id , bool trackChanges);
        void CreateProject(Project project);
        void DeleteProject(Project project);
    }
}
