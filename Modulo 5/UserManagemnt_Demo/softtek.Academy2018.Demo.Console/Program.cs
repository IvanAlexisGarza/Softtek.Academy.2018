using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business = Softtek.Academy2018.Demo.Business;
using Data = Softtek.Academy2018.Demo.Data;
using Domain = Softtek.Academy2018.Demo.Domain;

namespace softtek.Academy2018.Demo.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create new user
            Domain.Model.User user = new Domain.Model.User
            {
                IS = "JANU",
                FirstName = "Alfonso",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12),
            };

            IUserRepository fakerepository = new UserFakeRepository();

            IUserRepository repository = new UserDataRepository();

            IUserService service = new UserService(fakerepository);


            int id = service.Add(user);

            if(id == 0)
            {
                System.Console.WriteLine("Invalid User !!");
            }


            System.Console.WriteLine($"New user {user.Id} {user.IS} {user.FirstName} {user.LastName} {user.DateOfBirth}");

            repository.Update(user);

            user.IS = "HAM";
            user.FirstName = "Alfo";
            user.LastName = "Ram";
            user.DateOfBirth = new DateTime(1994, 1, 10);
            repository.Update(user);

            System.Console.WriteLine($"Updated {user.Id} {user.IS} {user.FirstName} {user.LastName} {user.DateOfBirth}");

            System.Console.ReadLine();

        }
    }
}
