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
            int expected = 1;

            Mock<IUserRepository> respository = new Mock<IUserRepository>();

            respository.Setup(x => x.Exist(It.IsAny<string>())).Returns(false);

            IUserService service = new UserService(respository.Object);

            User user = new User
            {
                IS = "JAMU",
                FirstName = "Alfonso",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1984, 12, 12)
            };

            int result = service.Add(user);

            Assert.AreEqual(expected, result);
        }
    }
}