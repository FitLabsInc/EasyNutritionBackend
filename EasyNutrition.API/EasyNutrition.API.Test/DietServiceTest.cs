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
    public class DietServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoDietsReturnsEmptyCollection()
        {
            var mockDietRepository = GetDefaultIDietRepositoryInstance();
            mockDietRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Diet>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new DietService(
                mockDietRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Diet> result = (List<Diet>)await service.ListAsync();
            int dietsCount = result.Count;

            // Assert
            dietsCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsDietNotFoundResponse()
        {
            // Arrange
            var mockDietRepository = GetDefaultIDietRepositoryInstance();
            var dietId = 1;
            mockDietRepository.Setup(r => r.FindById(dietId))
                .Returns(Task.FromResult<Diet>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new DietService(mockDietRepository.Object, mockUnitOfWork.Object);
            // Act
            DietResponse result = await service.GetByIdAsync(dietId);
            var message = result.Message;
            // Assert
            message.Should().Be("Diet not found");
        }

        private Mock<IDietRepository> GetDefaultIDietRepositoryInstance()
        {
            return new Mock<IDietRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}