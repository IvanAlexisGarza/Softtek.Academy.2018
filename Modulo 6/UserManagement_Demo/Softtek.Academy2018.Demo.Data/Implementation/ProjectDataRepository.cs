using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class ProjectDataRepository : IProjectRepository
    {
        public int Add(Project project)
        {
            using (var context = new UserManagementContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return project.Id;
            }
        }

        public ICollection<Project> GetAll()
        {
            using (var context = new UserManagementContext())
            {
                return context.Projects.ToList();
            }
        }

        public bool Exist(string name)
        {
            using (var context = new UserManagementContext())
            {
                return context.Projects.Any(e => e.Name.ToLower() == name.ToLower());
            }
        }

        public bool AddUser(int projectId, int userId)
        {
            using (var context = new UserManagementContext())
            {
                Project currentProject = context.Projects.SingleOrDefault(x => x.Id == projectId);

                if (currentProject == null) return false;

                User currentUser = context.Users.SingleOrDefault(x => x.Id == userId);

                if (currentUser == null) return false;

                currentProject.Colaborators.Add(currentUser);

                context.SaveChanges();

                return true;
            }
        }

        public ICollection<User> GetUsersByProject(int projectId)
        {
            using (var context = new UserManagementContext())
            {
                Project project = context.Projects.Include(x => x.Colaborators).SingleOrDefault();

                if (project == null || !project.Colaborators.Any()) return null;

                return project.Colaborators.ToList();
            }
        }

        public bool Exist(int projectId)
        {
            using (var context = new UserManagementContext())
            {
                return context.Projects.Any(x => x.Id == projectId);
            }
        }

        public bool ContainsUser(int projectId, int userId)
        {
            using (var context = new UserManagementContext())
            {
                return context.Projects.Any(p => p.Id == userId && p.Colaborators.Any(u => u.Id == userId));
            }
        }
    }
}
