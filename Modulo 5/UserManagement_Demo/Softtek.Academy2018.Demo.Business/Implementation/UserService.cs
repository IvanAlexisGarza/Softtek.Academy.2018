using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Add(User user)
        {
            if (string.IsNullOrEmpty(user.IS) ||
                string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName)) return 0;

            bool isExist = _userRepository.Exist(user.IS);

            if (isExist) return 0;

            if (!user.DateOfBirth.HasValue) return 0;

            bool validAge = DateTime.Now.Year - user.DateOfBirth.Value.Year > 18;

            if (!validAge) return 0;

            int id = _userRepository.Add(user);

            return id;
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;

            User user = _userRepository.Get(id);

            if (user == null || !user.IsActive) return false;

            return _userRepository.Delete(id);
        }

        public User Get(int id)
        {
            if (id <= 0) return null;

            User user = _userRepository.Get(id);

            if (user != null && !user.IsActive) return null;

            return user;
        }

        public bool Update(User user)
        {
            if (user.Id <= 0) return false;

            if (string.IsNullOrEmpty(user.IS) ||
                string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName)) return false;

            if (!user.DateOfBirth.HasValue) return false;

            bool validAge = DateTime.Now.Year - user.DateOfBirth.Value.Year > 18;

            if (!validAge) return false;

            string currentIS = _userRepository.GetIS(user.Id);

            if (string.IsNullOrEmpty(currentIS)) return false;

            bool existIS = _userRepository.Exist(user.IS);

            if (existIS && currentIS != user.IS) return false;

            return _userRepository.Update(user);
        }
    }
}
