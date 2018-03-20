using Softtek.Academy2018.Demo.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.Data.EntityFramework;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class UserDataRepository : IUserRepository
    {

        public int Add(User user)
        {
            User result = new User();
            using (var context = new DemoContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }

        public bool Delete(int id)
        {
            User result = new User();
            using (var context = new DemoContext())
            {
                result = context.Users.Where(x => x.Id == id).FirstOrDefault();
                result.IsActive = false;
                context.SaveChanges();
                return true;
            }
        }

        public bool Exist(string @is)
        {
            User result = new User();
            using (var context = new DemoContext())
            {
                result = context.Users.Find(@is);
                if (result != null) return true;

                else return false;
            }
        }

        public User Get(int id)
        {
            using (var context = new DemoContext())
            {
                return context.Users.Where(x => x.Id == id).FirstOrDefault() ?? null;
            }
        }

        public bool Update(User user)
        {

            using (var context = new DemoContext())
            {
                User result = new User();
                result = context.Users.Where(x => x.Id == user.Id).FirstOrDefault();

                result.Id = user.Id;
                result.IS = user.IS;
                result.IsActive = user.IsActive;
                result.LastName = user.LastName;
                result.ModDate = user.ModDate;
                result.Projects = user.Projects;
                result.Role = user.Role;
                result.Salary = user.Salary;
                context.SaveChanges();
            }
            return true;
        }
    }
}
