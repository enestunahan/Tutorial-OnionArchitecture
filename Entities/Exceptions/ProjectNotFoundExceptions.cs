namespace Entities.Exceptions
{
    public sealed class ProjectNotFoundExceptions : NotFoundException
    {
        public ProjectNotFoundExceptions(Guid projectId) :
             base($"The employee with {projectId} doesn't exists")
        {
        }
    }
}
