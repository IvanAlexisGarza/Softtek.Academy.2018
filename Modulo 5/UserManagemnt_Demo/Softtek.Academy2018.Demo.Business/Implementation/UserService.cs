using Softtek.Academy2018.Demo.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.Data.Contracts;

namespace Softtek.Academy2018.Demo.Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public void Add(User user)
        //{
        //    tr
        //};

        public int Add(User user)
        {
            bool isExist = _userRepository.Exist(user.IS);
            if (isExist) return 0;

            if (string.IsNullOrEmpty(user.FirstName) || 
                string.IsNullOrEmpty(user.LastName)) return 0;

            if (!user.DateOfBirth.HasValue) return 0;

            bool validAge = DateTime.Now.Year - user.DateOfBirth.Value.Year > 18;
            if (!validAge) return 0;

            int id = _userRepository.Add(user);
            return id;
        }

        public bool Exist(User user)
        {
            bool isExist = _userRepository.Exist(user.IS);
            if (isExist) return false;
            return true;
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
            User originalUser = _userRepository.Get(user.Id);

            if (originalUser != null)
            {
                if (_userRepository.Exist(user.IS))
                    {
                    if (originalUser.IS != user.IS)
                    {
                        Console.WriteLine("User IS already exists");
                        return false;
                    }
                    else
                    {
                        return _userRepository.Update(user);
                    } 
                }
            }
            Console.WriteLine("Could not find user");
            return false;
        }

    }
}
