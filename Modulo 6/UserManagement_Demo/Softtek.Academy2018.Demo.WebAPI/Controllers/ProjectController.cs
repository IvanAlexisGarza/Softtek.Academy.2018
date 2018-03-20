using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Softtek.Academy2018.Demo.WebAPI.Controllers
{
    [RoutePrefix("")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("API/Project")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] ProjectDTO projectDTO)
        {
            if (projectDTO == null) return BadRequest("Request is null");

            Project project = new Project
            {
                Id = projectDTO.Id,
                Name = projectDTO.Name,
                Area = projectDTO.Area,
                TechnologyStack = projectDTO.TechnologyStack
            };

            int newProjectId = _projectService.Add(project);

            if (newProjectId <= 0) return BadRequest("Unable to create user");

            var payload = new { UserId = newProjectId };

            return Ok(payload);
        }

        [Route("API/Projects")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
           ICollection<Project> projects =  _projectService.GetAll();

            if (projects == null) return BadRequest("No projects found");

            ICollection<ProjectDTO> projectsList = projects.Select(x => new ProjectDTO
            {
                Id = x.Id,
                Name = x.Name,
                Area = x.Area,
                TechnologyStack = x.TechnologyStack
            }).ToList();

            return Ok(projectsList);
        }
    }
}