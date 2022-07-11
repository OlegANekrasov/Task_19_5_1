using Moq;
using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceIntegrationTests
    {
        [Test]
        public void AuthenticateNotMustThrowUserNotFoundException()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(p => p.FindByEmail("Ivan@mail.ru")).Returns(new UserEntity());

            var userService = new UserService(mock.Object);
           
            var userAuthenticationData = new UserAuthenticationData()
            {
                Email = "Ivan@mail.ru"
            };

            Assert.That(userService.Authenticate(userAuthenticationData) is User);
        }

        [Test]
        public void AuthenticateMustThrowUserNotFoundException()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(p => p.FindByEmail("Oleg@mail.ru")).Throws(new UserNotFoundException());

            var userService = new UserService(mock.Object);

            var userAuthenticationData = new UserAuthenticationData()
            {
                Email = "Oleg@mail.ru"
            };

            Assert.Throws<UserNotFoundException>(() => userService.Authenticate(userAuthenticationData));
        }
    }
}