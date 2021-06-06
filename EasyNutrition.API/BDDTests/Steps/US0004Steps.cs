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
    public class US0004Steps
    {
        private static Mock<IUserRepository> userRepositoryMock;
        private static Mock<IRoleRepository> roleRepositoryMock;
        private static Mock<IUnitOfWork> unitofworkMock;
        private static UserService userService;
        private static Role nutritionistRole;
        private static User correctNutritionistUser;
        private static User incorrectNutritionistUser;
        [Given(@"an nutritionist")]
        public void GivenAnNutritionist()
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
            //Arrange:
            roleRepositoryMock.Setup(r => r.FindById(nutritionistRole.Id))
                .Returns(Task.FromResult(nutritionistRole));
        }

        [When(@"he starts registering")]
        public void WhenHeRegisters()
        {
            //Arrange:
            userRepositoryMock.Setup(r => r.AddAsync(new User()))
                .Throws(new Exception("Missing data"));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he registers incorrectly")]
        public void WhenHeRegistersIncorrectly()
        {
            userRepositoryMock.Setup(r => r.AddAsync(incorrectNutritionistUser))
                .Throws(new Exception("Error saving data"));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he registers correctly")]
        public void WhenHeRegistersCorrectly()
        {
            userRepositoryMock.Setup(r => r.AddAsync(correctNutritionistUser))
                .Returns(Task.FromResult(correctNutritionistUser));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he accept the registering form")]
        public void WhenHeAcceptTheRegisteringForm()
        {

            userRepositoryMock.Setup(r => r.AddAsync(correctNutritionistUser))
                .Returns(Task.FromResult(correctNutritionistUser));
            userService = new UserService(userRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [Then(@"the system will ask for his information")]
        public async void ThenTheSystemWillAskForHisInformation()
        {
            var response = await userService.SaveAsync(new User());
            response.Success.Should().BeFalse();
            response.Message.Should().Be("An error ocurred while saving user: Missing data");
        }
        
        [Then(@"the system will show an error message and not register the nutritionist")]
        public async void ThenTheSystemWillShowAnErrorMessageAndNotRegisterTheNutritionist()
        {
            var response = await userService.SaveAsync(incorrectNutritionistUser);
            response.Success.Should().BeFalse();
            response.Message.Should().Be("An error ocurred while saving user: Error saving data");
        }
        
        [Then(@"the system will show the registering form, waiting validations")]
        public async void ThenTheSystemWillShowTheRegisteringFormWaitingValidations()
        {
            var response = await userService.SaveAsync(correctNutritionistUser);
            response.Success.Should().BeTrue();
        }
        
        [Then(@"the system will send a confirmation")]
        public async void ThenTheSystemWillSendAConfirmation()
        {
            var response = await userService.SaveAsync(correctNutritionistUser);
            response.Success.Should().BeTrue();
        }
    }
}
