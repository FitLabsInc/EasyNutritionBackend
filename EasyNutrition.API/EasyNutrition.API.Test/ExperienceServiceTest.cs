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
    public class ExperienceServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoExperiencesReturnsEmptyCollection()
        {
            var mockExperienceRepository = GetDefaultIExperienceRepositoryInstance();
            mockExperienceRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Experience>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ExperienceService(
                mockExperienceRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Experience> result = (List<Experience>)await service.ListAsync();
            int experiencesCount = result.Count;

            // Assert
            experiencesCount.Should().Equals(0);
        }

        private Mock<IExperienceRepository> GetDefaultIExperienceRepositoryInstance()
        {
            return new Mock<IExperienceRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}