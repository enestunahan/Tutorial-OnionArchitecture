using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Tutorial_OnionArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/employees")]

    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllEmployeeByProjectId(Guid projectId)
        {
                var employeeList = _service
                    .EmployeeService
                    .GetAllEmployeesByProjectId(projectId, false);

                return Ok(employeeList);          
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOneEmployeeByProjectId(Guid projectId, Guid id)
        {
                var employee = _service
                    .EmployeeService
                    .GetOneEmployeeByProjectId(projectId, id, false);

                return Ok(employee);
        }
    }
}
