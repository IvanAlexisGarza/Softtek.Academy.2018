using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy2018.Demo.Business.Implementation
{
    public class ProjectUserService : IProjectUserService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public ProjectUserService(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public bool AddUserToProject(int projectId, int userId)
        {
            if (projectId <= 0 || userId <= 0) return false;

            bool projectExist = _projectRepository.Exist(projectId);

            if (!projectExist) return false;

            bool userExist = _userRepository.Exist(userId);

            if (!userExist) return false;

            bool projectContainsUser = _projectRepository.ContainsUser(projectId, userId);

            if (projectContainsUser) return false;

            return _projectRepository.AddUser(projectId, userId);
        }

        public ICollection<User> GetUsersByProject(int projectId)
        {
            if (projectId <= 0) return null;

            return _projectRepository.GetUsersByProject(projectId);
        }
    }
}
