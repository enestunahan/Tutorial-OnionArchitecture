using Contracts;
using Entities.Models;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateEmployeeForProject(Guid projectId, Employee employee)
        {
            employee.ProjectId = projectId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
           Delete(employee);
        }

        public Employee GetEmployeeByProjectId(Guid projectId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.ProjectId.Equals(projectId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Employee> GetEmployeesByProjectId(Guid projectId, bool trackChanges) =>
            FindByCondition(e => e.ProjectId.Equals(projectId), trackChanges)
            .OrderBy(e => e.FirstName)
            .ToList();
    }
}
