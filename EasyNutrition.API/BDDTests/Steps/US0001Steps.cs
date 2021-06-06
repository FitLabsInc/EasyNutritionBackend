using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services.Communication;
using EasyNutrition.API.Services;
using FluentAssertions;
using TechTalk.SpecFlow;
using Moq;
using NUnit.Framework;

namespace BDDTests.Steps
{
    [Binding]
    public class US0001Steps
    {
        private static Mock<IUserRepository> userRepositoryMock;
        private static Mock<IRoleRepository> roleRepositoryMock;
        private static Mock<IUnitOfWork> unitofworkMock;
        private static Mock<ISubscriptionRepository> subscriptionRepositoryMock;
        private static UserService userService;
        private static SubscriptionService subscriptionService;
        private static User adminUser;
        private static User clientUser;
        private static Role adminRole;
        private static Role clientRole;
        private static Subscription subscription;
        private static Subscription wrongSubscription;

        [Given(@"an administrator logged in")]
        public void GivenAnAdministratorLoggedIn()
        {
            //Variable setup:
            userRepositoryMock = new Mock<IUserRepository>();
            roleRepositoryMock = new Mock<IRoleRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
            adminRole = new Role
            {
                Id = 3,
                Name = "Administrador"
            };
            clientRole = new Role
            {
                Id = 2,
                Name = "Cliente"
            };
            adminUser = new User
            {
                Id = 1,
                Role = adminRole
            };
            clientUser = new User
            {
                Id = 2,
                Role = clientRole
            };
            subscription = new Subscription
            {
                Active = true,
                Id = 1,
                MaxSessions = 1,
                Price = 5,
                UserId = clientUser.Id,
                User = clientUser
            };
            wrongSubscription = new Subscription
            {
                Active = true,
                Id = 1,
                MaxSessions = -1,
                User = clientUser,
                Price = -1,
                UserId = clientUser.Id
            };

            //Arrange
            userRepositoryMock.Setup(r => r.FindById(adminUser.Id))
                .Returns(Task.FromResult<User>(adminUser));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }

        [When(@"loads the subscriptions section")]
        public void WhenLoadsTheSubscriptionsSection()
        {
            //Arrange
            subscriptionRepositoryMock.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Subscription> { subscription });
            subscriptionRepositoryMock.Setup(r => r.FindById(subscription.Id))
                .ReturnsAsync(subscription);
            subscriptionRepositoryMock.Setup(r => r.AddAsync(subscription));
            subscriptionService = new SubscriptionService(subscriptionRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"creating a new new subscription a field is completed wrong")]
        public void WhenAFieldIsCompletedWrong()
        {
            subscriptionRepositoryMock.Setup(r => r.AddAsync(wrongSubscription))
                .Throws(new ArgumentException("Error in numbers, cant be negative"));
        }
        
        [When(@"he delete a subscription")]
        public void WhenHeDeleteASubscription()
        {
            subscriptionRepositoryMock.Setup(r => r.Remove(subscription));
        }
        
        [Then(@"the system will display all the plans")]
        public async void ThenTheSystemWillDisplayAllThePlans()
        {
            var response = await subscriptionService.ListAsync();
            response.Count().Should().Be(2);
        }
        
        [Then(@"the system will display the detail of that subscription")]
        public async void ThenTheSystemWillDisplayTheDetailOfThatSubscription()
        {
            var response = await subscriptionService.GetByIdAsync(subscription.Id);
            response.Should().Be(subscription);
        }
        
        [Then(@"he can create a new subscription")]
        public async void ThenHeCanCreateANewSubscription()
        {
            var response = await subscriptionService.SaveAsync(subscription);
            response.Success.Should().BeTrue();//Significa que la subscripción se creo con exito
        }
        
        [Then(@"the system should show a error message")]
        public async void ThenTheSystemShouldShowAErrorMessage()
        {
            var response = await subscriptionService.SaveAsync(wrongSubscription);
            response.Success.Should().BeFalse();
            response.Message.Should().Contain("An error ocurred");
        }

        [Then(@"the system should show a warning message")]
        public async void ThenTheSystemShouldShowAWarningMessage()
        {
            var response = await subscriptionService.DeleteAsync(subscription.Id);
            response.Message.Should().Contain("confirm");
        }
    }
}
