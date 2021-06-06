using System;
using System.Threading.Tasks;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Services;
using FluentAssertions;
using Moq;
using TechTalk.SpecFlow;

namespace BDDTests.Steps
{
    [Binding]
    public class US0007Steps
    {
        private static Mock<IUserRepository> userRepositoryMock;
        private static Mock<IRoleRepository> roleRepositoryMock;
        private static Mock<IUnitOfWork> unitofworkMock;
        private static UserService userService;
        private static Role nutritionistRole;
        private static User correctNutritionistUser;
        private static User incorrectNutritionistUser;
        [Given(@"a nutritionist7 logged in succesfully")]
        public void GivenANutritionistLoggedInSuccesfully()
        {
            //Variable setup
            userRepositoryMock = new Mock<IUserRepository>();
            roleRepositoryMock = new Mock<IRoleRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            nutritionistRole = new Role
            {
                Id = 1,
                Name = "Nutricionista"
            };
            correctNutritionistUser = new User
            {
                Id = 1,
                Role = nutritionistRole,
                RoleId = nutritionistRole.Id,
                Username = "Username",
                Password = "Password123#",
                Name = "Nombre",
                Lastname = "Apellido",
                Birthday = "1/1/2000",
                Email = "email@org.com",
                Phone = "123456789",
                Address = "Direccion del usuario"
            };
            incorrectNutritionistUser = new User
            {
                Id = 1,
                Role = nutritionistRole,
                RoleId = nutritionistRole.Id,
                Username = "",
                Password = "Password123#",
                Name = "Nombre",
                Lastname = "Apellido",
                Birthday = "0/0/2000",
                Email = "correoincorrecto",
                Phone = "",
                Address = "Direccion del usuario"
            };
            roleRepositoryMock.Setup(r => r.FindById(nutritionistRole.Id))
                .Returns(Task.FromResult(nutritionistRole));
        }
        
        [When(@"he enters to his profile")]
        public void WhenHeEntersToHisProfile()
        {
            userRepositoryMock.Setup(r => r.FindById(correctNutritionistUser.Id))
                .ReturnsAsync(correctNutritionistUser);
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he is editing his profile")]
        public void WhenHeIsEditingHisProfile()
        {
            userRepositoryMock.Setup(r => r.FindById(correctNutritionistUser.Id))
                .ReturnsAsync(correctNutritionistUser);
            userRepositoryMock.Setup(r => r.Update(correctNutritionistUser));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he update his profile with incorrect data")]
        public void WhenHeUpdateHisProfileWithIncorrectData()
        {
            userRepositoryMock.Setup(r => r.FindById(correctNutritionistUser.Id))
                .ReturnsAsync(correctNutritionistUser);
            userRepositoryMock.Setup(r => r.Update(incorrectNutritionistUser))
                .Throws(new Exception("Error saving data"));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        
        [Then(@"the system will show his user data")]
        public async void ThenTheSystemWillShowHisUserData()
        {
            var response = await userService.GetByIdAsync(correctNutritionistUser.Id);
            response.Success.Should().BeTrue();
        }
        
        [Then(@"the system will allow him to edit his photo, personal data and payment methods")]
        public async void ThenTheSystemWillAllowHimToEditHisPhotoPersonalDataAndPaymentMethods()
        {
            var response = await userService.UpdateAsync(correctNutritionistUser.Id, correctNutritionistUser);
            response.Success.Should().BeTrue();
        }
        
        [Then(@"the system will send error and not update his profile")]
        public async void ThenTheSystemWillSendErrorAndNotUpdateHisProfile()
        {
            var response = await userService.UpdateAsync(incorrectNutritionistUser.Id, incorrectNutritionistUser);
            response.Success.Should().BeFalse();
            response.Message.Should().Be("An error ocurred while saving user: Error saving data");
        }
        
    }
}
