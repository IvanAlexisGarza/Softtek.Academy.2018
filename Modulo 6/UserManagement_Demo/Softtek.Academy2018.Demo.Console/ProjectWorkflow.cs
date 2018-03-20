using Softtek.Academy2018.Demo.Console.ProjectManagementService_Ref;

namespace Softtek.Academy2018.Demo.Console
{
    public class ProjectWorkflow
    {
        private readonly ProjectManagementServiceClient projectService;

        public ProjectWorkflow(ProjectManagementServiceClient ProjectService)
        {
            projectService = ProjectService;
        }

        public void Create()
        {
            System.Console.WriteLine("---Create new Project---");

            System.Console.Write("Name:");
            string Name = System.Console.ReadLine();
            System.Console.Write("Area:");
            string Area = System.Console.ReadLine();
            System.Console.Write("TechnologyStack:");
            string TechnologyStack = System.Console.ReadLine();

            CreateProjectRequest project = new CreateProjectRequest
            {
                Name = Name,
                Area = Area,
                TechnologyStack = TechnologyStack
            };

            CreateProjectResponse response = projectService.CreateProject(project);

            if (response == null)
            {
                System.Console.WriteLine("Error, Response is null");
                System.Console.WriteLine("------------------");
                return;
            }

            if (response.ProjectId <= 0)
            {
                System.Console.WriteLine($"Error: {response.Message}");
                System.Console.WriteLine("------------------");
                return;
            }

            System.Console.WriteLine($"Success: project created, Id: {response.ProjectId}");
            System.Console.WriteLine("------------------");
        }

        public void GetAllProjects()
        {
            System.Console.WriteLine("Get all the projects...");

            GetAllProjectsResponse response = projectService.GetAllProjects(new GetAllProjectsRequest());

            if (response == null)
            {
                System.Console.WriteLine("Error: Response is null");
                System.Console.WriteLine("------------------");
                return;
            }

            foreach (var p in response.ProjectList)
            {
                System.Console.WriteLine($"Id {p.Id}\n" +
                    $"Area {p.Area}\n" +
                    $"Name {p.Name}\n" +
                    $"Technology Stack {p.TechnologyStack}");
                System.Console.WriteLine("-------------");
            }
        }
    }
}
