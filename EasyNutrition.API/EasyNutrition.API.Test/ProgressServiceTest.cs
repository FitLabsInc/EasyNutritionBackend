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
    public class ProgressServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoProgresssReturnsEmptyCollection()
        {
            var mockProgressRepository = GetDefaultIProgressRepositoryInstance();
            mockProgressRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Progress>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ProgressService(
                mockProgressRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Progress> result = (List<Progress>)await service.ListAsync();
            int progressesCount = result.Count;

            // Assert
            progressesCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsProgressNotFoundResponse()
        {
            // Arrange
            var mockProgressRepository = GetDefaultIProgressRepositoryInstance();
            var progressId = 1;
            mockProgressRepository.Setup(r => r.FindById(progressId))
                .Returns(Task.FromResult<Progress>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ProgressService(mockProgressRepository.Object, mockUnitOfWork.Object);
            // Act
            ProgressResponse result = await service.GetByIdAsync(progressId);
            var message = result.Message;
            // Assert
            message.Should().Be("Progress not found");
        }

        private Mock<IProgressRepository> GetDefaultIProgressRepositoryInstance()
        {
            return new Mock<IProgressRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}