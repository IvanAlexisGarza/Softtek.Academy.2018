using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WCF.Messages;

namespace Softtek.Academy2018.Demo.WCF
{
    public class ProjectManagementService : IProjectManagementService
    {
        public readonly IProjectService _projectService;

        public ProjectManagementService()
        {
            IProjectRepository repository = new ProjectDataRepository();
            _projectService = new ProjectService(repository);
        }

        public CreateProjectResponse CreateProject(CreateProjectRequest request)
        {
            if (request == null)
            {
                return new CreateProjectResponse { Success = false, Message = "Request is null" };
            }

            Project project = new Project
            {
                Name = request.Name,
                Area = request.Area,
                TechnologyStack = request.TechnologyStack
            };

            int id = _projectService.Add(project);

            if (id <= 0)
            {
                return new CreateProjectResponse { Success = false, Message = "Unable to create project" };
            }

            return new CreateProjectResponse
            {
                Success = true,
                ProjectId = id
            };
        }

        public GetAllProjectsResponse GetAllProjects(GetAllProjectsRequest request)
        {
            if (request == null)
            {
                return new GetAllProjectsResponse { Success = false, Message = "Request is null" };
            }

            ICollection<Project> projects = _projectService.GetAll();

            if (projects == null) return new GetAllProjectsResponse
            {
                Success = false,
                Message = "Error: Unable to get projects"
            };

            ICollection<ProjectDTO> projectList = projects.Select(p => new ProjectDTO { Id = p.Id,
            Name = p.Name,
            Area = p.Area,
            TechnologyStack = p.TechnologyStack}).ToList();

            return new GetAllProjectsResponse
            {
                Success = true,
                ProjectList = projectList
            };
            
        }
    }
}
