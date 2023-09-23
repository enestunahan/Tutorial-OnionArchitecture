using Contracts;
using Entities.Models;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProject(Project project) => Create(project);

        public void DeleteProject(Project project) => Delete(project);

        public IEnumerable<Project> GetAllProjects(bool trackChanges) => 
             FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToList();


        public Project GetProject(Guid id, bool trackChanges) =>
            FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }
}
