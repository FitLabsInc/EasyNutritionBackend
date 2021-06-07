using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Domain.Services.Communication;
using EasyNutrition.API.Services;
using FluentAssertions;
using TechTalk.SpecFlow;
using Moq;
using NUnit.Framework;

namespace BDDTests.Steps
{
    [Binding]
    public class US0005Steps
    {
        private static Mock<IUserRepository> userRepositoryMock;
        private static Mock<IRoleRepository> roleRepositoryMock;
        private static Mock<IUnitOfWork> unitofworkMock;
        private static Mock<IDietRepository> dietRepositoryMock;
        private static UserService userService;
        private static DietService dietService;
        private static Diet diet;
        private static User adminUser;
        private static User clientUser;
        private static Role adminRole;
        private static Role clientRole;

        [Given(@"a nutritionist logged in succesfully")]
        public void GivenAnAdministratorLoggedIn()
        {
            //Variable setup:
            userRepositoryMock = new Mock<IUserRepository>();
            roleRepositoryMock = new Mock<IRoleRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            dietRepositoryMock = new Mock<IDietRepository>();
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

            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };

            //Arrange
            userRepositoryMock.Setup(r => r.FindById(adminUser.Id))
                .Returns(Task.FromResult<User>(adminUser));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [Given(@"the nutritionist is in the diet section")]
        public void GivenANutritionistIsInTheDietSection()
        {
            //Variable setup:
            userRepositoryMock = new Mock<IUserRepository>();
            roleRepositoryMock = new Mock<IRoleRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            dietRepositoryMock = new Mock<IDietRepository>();
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

            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };

            //Arrange
            userRepositoryMock.Setup(r => r.FindById(adminUser.Id))
                .Returns(Task.FromResult<User>(adminUser));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [Given(@"the nutritionist is in the form to upload a new diet")]
        public void GivenANutritionistIsInTheFormToUploadANewDiet()
        {
            //Variable setup:
            unitofworkMock = new Mock<IUnitOfWork>();
            dietRepositoryMock = new Mock<IDietRepository>();
            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };
        }
        
        [Given(@"the nutritionist is in the list of diets")]
        public void GivenANutritionistIsInTheListOfDiets()
        {
            //Variable setup:
            unitofworkMock = new Mock<IUnitOfWork>();
            dietRepositoryMock = new Mock<IDietRepository>();
            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };
        }

        [When(@"he goes to diet section")]
        public void WhenNutritionistGoesToDietSection()
        {
            //Arrange
            dietRepositoryMock.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Diet> { diet });

            dietService = new DietService(dietRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he clicks to upload a new diet")]
        public void WhenNutritionistClicksToUploadANewDiet()
        {
            dietRepositoryMock.Setup(r => r.AddAsync(diet));
            dietService = new DietService(dietRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he has filled in the fields correctly and clicks to create diet")]
        public void WhenNutritionistFilledANewDiet()
        {
            dietRepositoryMock.Setup(r => r.AddAsync(diet));
            dietService = new DietService(dietRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he has filled in the fields incorrectly and clicks to create diet")]
        public void WhenNutritionistFilledANewDietIncorrectly()
        {
            dietRepositoryMock.Setup(r => r.AddAsync(diet))
                .Throws(new ArgumentException("Error in data"));
            dietService = new DietService(dietRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he clicks to delete diet")]
        public void WhenNutritionistClicksToDeleteDiet()
        {
            dietRepositoryMock.Setup(r => r.Remove(diet));
            dietService = new DietService(dietRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [Then(@"the system should show the diet list uploaded to the platform by him")]
        public async void ThenTheSystemShouldShowTheDietListUploadedToThePlatformByHim()
        {
            var response = await dietService.ListAsync();
            response.Count().Should().Be(1);
        }
        
        [Then(@"the system will show a form to upload a new diet, where he will have to fill in all the data required by the form")]
        public async void ThenTheSystemShowAFormToNewDiet()
        {
            var response = await dietService.SaveAsync(diet);
            response.Success.Should().BeTrue();
        }
        
        [Then(@"the system will save said resource in the database")]
        public async void ThenTheSystemWillSave()
        {
            var response = await dietService.SaveAsync(diet);
            response.Success.Should().BeTrue();
        }
        
        [Then(@"the system will show an error message detailing the wrong fields and a new diet will not be created")]
        public async void ThenTheSystemWontSaveAndShowError()
        {
            var response = await dietService.SaveAsync(diet);
            response.Success.Should().BeFalse();
            response.Message.Should().Contain("Error in data");
        }
        [Then(@"the system will show a confirmation window and if he clicks to accept the diet is eliminated from the system")]
        public async void ThenTheSystemWillShowAConfirmationIfDietHasBeenDeleted()
        {
            var response = await dietService.DeleteAsync(diet.Id);
            response.Success.Should().BeTrue();
        }
    }
}
