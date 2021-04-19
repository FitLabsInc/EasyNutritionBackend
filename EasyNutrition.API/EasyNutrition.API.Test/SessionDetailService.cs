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
    public class SessionDetailServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoSessionDetailsReturnsEmptyCollection()
        {
            var mockSessionDetailRepository = GetDefaultISessionDetailRepositoryInstance();
            mockSessionDetailRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<SessionDetail>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SessionDetailService(
                mockSessionDetailRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<SessionDetail> result = (List<SessionDetail>)await service.ListAsync();
            int sessionDetailssCount = result.Count;

            // Assert
            sessionDetailssCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsSessionDetailNotFoundResponse()
        {
            // Arrange
            var mockSessionDetailRepository = GetDefaultISessionDetailRepositoryInstance();
            var sessionDetailsId = 1;
            mockSessionDetailRepository.Setup(r => r.FindById(sessionDetailsId))
                .Returns(Task.FromResult<SessionDetail>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SessionDetailService(mockSessionDetailRepository.Object, mockUnitOfWork.Object);
            // Act
            SessionDetailResponse result = await service.GetByIdAsync(sessionDetailsId);
            var message = result.Message;
            // Assert
            message.Should().Be("SessionDetail not found");
        }

        private Mock<ISessionDetailRepository> GetDefaultISessionDetailRepositoryInstance()
        {
            return new Mock<ISessionDetailRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}