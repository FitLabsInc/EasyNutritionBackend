using EasyNutrition.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Services;
using EasyNutrition.API.Domain.Services.Communication;

namespace EasyNutrition.API.Test
{
    public class UserServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoUsersReturnsEmptyCollection()
        {
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            mockUserRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<User>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new UserService(
                mockUserRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<User> result = (List<User>)await service.ListAsync();
            int usersCount = result.Count;

            // Assert
            usersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsUserNotFoundResponse()
        {
            // Arrange
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var userId = 1;
            mockUserRepository.Setup(r => r.FindById(userId))
                .Returns(Task.FromResult<User>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new UserService(mockUserRepository.Object, mockUnitOfWork.Object);
            // Act
            UserResponse result = await service.GetByIdAsync(userId);
            var message = result.Message;
            // Assert
            message.Should().Be("User not found");
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}