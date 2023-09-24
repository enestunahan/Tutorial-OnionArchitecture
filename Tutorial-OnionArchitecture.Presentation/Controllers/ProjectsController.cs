﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Tutorial_OnionArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ProjectsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _serviceManager.ProjectService.GetAllProjects(false);
                return Ok(projects);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }         
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProjectById(Guid id)
        {
            try
            {
                var project = _serviceManager.ProjectService.GetProjectById(id);
                return Ok(project);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }
    }
}
