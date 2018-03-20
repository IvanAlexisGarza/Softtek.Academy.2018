using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Business.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _dataRepo;

        public ProjectService(IProjectRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public int Add(Project project)
        {
            if (project.Id != 0) return 0;

            if (string.IsNullOrEmpty(project.Name)|| string.IsNullOrEmpty(project.Area)) return 0;

            if (project.Colaborators.Count != 0) return 0;

            bool UserNameExist = _dataRepo.Exist(project.Name);

            if (UserNameExist) return 0;

            int id = _dataRepo.Add(project);

            return id;
        }

        public ICollection<Project> GetAll()
        {
            return _dataRepo.GetAll();
        }
    }
}
