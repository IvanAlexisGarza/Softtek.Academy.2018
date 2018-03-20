using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data.Contracts
{
    public interface IUserRepository
    {
        int Add(User User);

        User Get(int Id);

        bool Update(User user);

        bool Delete(int id);

        bool Exist(string @is);
    }
}
