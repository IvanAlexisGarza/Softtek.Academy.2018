using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class UserFakeRepository : IUserRepository
    {
        private static List<User> _users = new List<User>();

        public int Add(User user)
        {
            int id = _users.Count + 1;

            user.Id = id;
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = null;
            user.IsActive = true;

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

        public bool Exist(int userId, bool includeInactive = false)
        {
            return _users.Any(x => x.Id == userId && (includeInactive || (!includeInactive && x.IsActive)));
        }

        public User Get(int id)
        {
            User currentUser = _users.SingleOrDefault(x => x.Id == id && x.IsActive);

            if (currentUser != null)
            {
                return new User
                {
                    Id = currentUser.Id,
                    IS = currentUser.IS,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    DateOfBirth = currentUser.DateOfBirth,
                    Salary = currentUser.Salary,
                    IsActive = currentUser.IsActive,
                    CreatedDate = currentUser.CreatedDate,
                    ModifiedDate = currentUser.ModifiedDate
                };
            }

            return null;
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetIS(int id)
        {
            return _users.SingleOrDefault(x => x.Id == id).IS ?? null;
        }

        public bool Update(User user)
        {
            User currentUser = _users.SingleOrDefault(x => x.Id == user.Id);

            if (currentUser == null) return false;

            currentUser.IS = user.IS;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.DateOfBirth = user.DateOfBirth;
            currentUser.Salary = user.Salary;
            currentUser.ModifiedDate = DateTime.Now;

            return true;
        }
    }
}
