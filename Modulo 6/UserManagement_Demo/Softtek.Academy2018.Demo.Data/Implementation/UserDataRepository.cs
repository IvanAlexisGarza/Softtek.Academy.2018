using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data.Implementation
{
    public class UserDataRepository : IUserRepository
    {
        public int Add(User user)
        {
            using (var ctx = new UserManagementContext())
            {
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = null;
                user.IsActive = true;

                ctx.Users.Add(user);

                ctx.SaveChanges();

                return user.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new UserManagementContext())
            {
                User currentUser = ctx.Users.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (currentUser == null) return false;

                currentUser.IsActive = false;

                ctx.Entry(currentUser).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public ICollection<User> GetAll()
        {
            using (var context = new UserManagementContext())
            {
                return context.Users.ToList();
            }
        }

        public bool Exist(string @is)
        {
            using (var ctx = new UserManagementContext())
            {
                return ctx.Users.AsNoTracking().Any(x => x.IS.ToLower() == @is.ToLower());
            }
        }

        public bool Exist(int userId, bool includeInactive = false)
        {
            using (var context = new UserManagementContext())
            {
                return context.Users.Any(x => x.Id == userId && (includeInactive || (!includeInactive && x.IsActive)));
            }
        }

        public User Get(int id)
        {
            using (var ctx = new UserManagementContext())
            {
                return ctx.Users.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public string GetIS(int id)
        {
            using (var ctx = new UserManagementContext())
            {
                return ctx.Users.SingleOrDefault(x => x.Id == id).IS ?? null;
            }
        }

        public bool Update(User user)
        {
            using (var ctx = new UserManagementContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == user.Id);

                if (currentUser == null) return false;

                currentUser.IS = user.IS;
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.DateOfBirth = user.DateOfBirth;
                currentUser.Salary = user.Salary;
                currentUser.ModifiedDate = DateTime.Now;

                ctx.Entry(currentUser).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }
    }
}
