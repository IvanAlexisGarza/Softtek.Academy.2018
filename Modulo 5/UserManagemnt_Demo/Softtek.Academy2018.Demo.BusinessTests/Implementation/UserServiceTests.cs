using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Business.Implementation.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void When_add_a_valid_user()
        {
            int expectedId = 1;

            Mock<IUserRepository> repository = new Mock<IUserRepository>();

            repository.Setup(x => x.Exist("JANU")).Returns(false);

            IUserService service = new UserService(repository.Object);

            User user = new User
            {
                IS = "JANU",
                FirstName = "Alfonso",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12),
            };

            //int resultId = service.Exist(user);

          //  Assert.AreEqual(expectedId, resultId);
        }
    }
}