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
    public class SessionServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoSessionsReturnsEmptyCollection()
        {
            var mockSessionRepository = GetDefaultISessionRepositoryInstance();
            mockSessionRepository.Setup(r => r.LisAsync())
                .ReturnsAsync(new List<Session>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SessionService(
                mockSessionRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Session> result = (List<Session>)await service.ListAsync();
            int sessionsCount = result.Count;

            // Assert
            sessionsCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsSessionNotFoundResponse()
        {
            // Arrange
            var mockSessionRepository = GetDefaultISessionRepositoryInstance();
            var sessionId = 1;
            mockSessionRepository.Setup(r => r.FindById(sessionId))
                .Returns(Task.FromResult<Session>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SessionService(mockSessionRepository.Object, mockUnitOfWork.Object);
            // Act
            SessionResponse result = await service.GetByIdAsync(sessionId);
            var message = result.Message;
            // Assert
            message.Should().Be("Session not found");
        }

        private Mock<ISessionRepository> GetDefaultISessionRepositoryInstance()
        {
            return new Mock<ISessionRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}