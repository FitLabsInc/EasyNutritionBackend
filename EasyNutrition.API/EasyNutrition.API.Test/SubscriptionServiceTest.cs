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
    public class SubscriptionServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoSubscriptionsReturnsEmptyCollection()
        {
            var mockSubscriptionRepository = GetDefaultISubscriptionRepositoryInstance();
            mockSubscriptionRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Subscription>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SubscriptionService(
                mockSubscriptionRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Subscription> result = (List<Subscription>)await service.ListAsync();
            int subscriptionsCount = result.Count;

            // Assert
            subscriptionsCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsSubscriptionNotFoundResponse()
        {
            // Arrange
            var mockSubscriptionRepository = GetDefaultISubscriptionRepositoryInstance();
            var subscriptionId = 1;
            mockSubscriptionRepository.Setup(r => r.FindById(subscriptionId))
                .Returns(Task.FromResult<Subscription>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new SubscriptionService(mockSubscriptionRepository.Object, mockUnitOfWork.Object);
            // Act
            SubscriptionResponse result = await service.GetByIdAsync(subscriptionId);
            var message = result.Message;
            // Assert
            message.Should().Be("Subscription not found");
        }

        private Mock<ISubscriptionRepository> GetDefaultISubscriptionRepositoryInstance()
        {
            return new Mock<ISubscriptionRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}