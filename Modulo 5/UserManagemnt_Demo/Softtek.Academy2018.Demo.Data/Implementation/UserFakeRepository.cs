using Softtek.Academy2018.Demo.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class UserFakeRepository : IUserRepository
    {
        private static List<User> _users = new List<User>();

        public int Add(User user)
        {
            int id = _users.Count + 1;
            user.Id = id;
            _users.Add(user);

            return id;
        }

        public bool Delete(int id)
        {
            User user = _users.SingleOrDefault(x => x.Id == id);

            if (user == null) return false;

            user.IsActive = false;

            return true;
        }

        public bool Exist(string @is)
        {
            return _users.Any(x => x.IS.ToLower() == @is.ToLower());
        }

        public User Get(int id)
        {
            User user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                Salary = user.Salary,
                IS = user.IS,
                CreatedDate = user.CreatedDate,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                IsActive = user.IsActive,
                LastName = user.LastName,
                ModDate = user.ModDate,
                Projects = user.Projects,
                Role = user.Role
            };
        }

        public bool Update(User user)
        {
            User tempUser = _users.Where(x => x.Id == user.Id).SingleOrDefault();

            tempUser.Id = user.Id;
            tempUser.IS = user.IS;
            tempUser.FirstName = user.FirstName;
            tempUser.IsActive = user.IsActive;
            tempUser.LastName = user.LastName;
            tempUser.ModDate = user.ModDate;
            tempUser.Projects = user.Projects;
            tempUser.Role = user.Role;
            tempUser.Salary = user.Salary;
            tempUser.DateOfBirth = user.DateOfBirth;

            return true; 
        }
    }
}
