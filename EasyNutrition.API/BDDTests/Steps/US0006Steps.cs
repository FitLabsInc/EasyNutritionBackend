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
    public class US0006Steps
    {
        private static Mock<IUserRepository> userRepositoryMock;
        private static Mock<IUnitOfWork> unitofworkMock;
        private static Mock<ISessionRepository> sessionRepositoryMock;
        private static Mock<IProgressRepository> progressRepositoryMock;
        private static UserService userService;
        private static SessionService sessionService;
        private static ProgressService progressService;
        private static Diet diet;
        private static User nutritionistUser;
        private static User patientUser;
        private static Role nutritionistRole;
        private static Role patientRole;
        private static Session session;
        private static SessionDetail sessionDetail;
        private static Progress progress;

        [Given(@"a nutritionist logged in")]
        public void GivenANutritionistLoggedIn()
        {
            //Variable setup:
            userRepositoryMock = new Mock<IUserRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            sessionRepositoryMock = new Mock<ISessionRepository>();
            nutritionistRole = new Role
            {
                Id = 3,
                Name = "Nutricionista"
            };
            patientRole = new Role
            {
                Id = 2,
                Name = "Paciente"
            };
            nutritionistUser = new User
            {
                Id = 1,
                Role = nutritionistRole
            };
            patientUser = new User
            {
                Id = 2,
                Role = patientRole
            };

            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };
            
            sessionDetail = new SessionDetail
            {
                Id = 1,
                Session = session,
                User = patientUser
            };
            
            session = new Session
            {
                Id = 1,
                Diets = new List<Diet> {diet},
                Link = "link",
                User = nutritionistUser,
                SessionDetails = new List<SessionDetail>{ sessionDetail }
            };
        }
        
        [Given(@"a nutritionist is in patient section")]
        public void GivenANutritionistIsInPatientSection()
        {
            //Variable setup:
            userRepositoryMock = new Mock<IUserRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            sessionRepositoryMock = new Mock<ISessionRepository>();
            progressRepositoryMock = new Mock<IProgressRepository>();
            nutritionistRole = new Role
            {
                Id = 3,
                Name = "Nutricionista"
            };
            patientRole = new Role
            {
                Id = 2,
                Name = "Paciente"
            };
            nutritionistUser = new User
            {
                Id = 1,
                Role = nutritionistRole
            };
            patientUser = new User
            {
                Id = 2,
                Role = patientRole
            };

            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };
            
            sessionDetail = new SessionDetail
            {
                Id = 1,
                Session = session,
                User = patientUser
            };
            
            session = new Session
            {
                Id = 1,
                Diets = new List<Diet> {diet},
                Link = "link",
                User = nutritionistUser,
                SessionDetails = new List<SessionDetail>{ sessionDetail }
            };

            progress = new Progress
            {
                Id = 1,
                Description = "Una descripción",
                Session = session
            };
        }
        
        [Given(@"a nutritionist is in the fill advance report section")]
        public void GivenANutritionistIsInTheFillAdvanceReportSection()
        {
            //Variable setup:
            userRepositoryMock = new Mock<IUserRepository>();
            unitofworkMock = new Mock<IUnitOfWork>();
            sessionRepositoryMock = new Mock<ISessionRepository>();
            progressRepositoryMock = new Mock<IProgressRepository>();
            nutritionistRole = new Role
            {
                Id = 3,
                Name = "Nutricionista"
            };
            patientRole = new Role
            {
                Id = 2,
                Name = "Paciente"
            };
            nutritionistUser = new User
            {
                Id = 1,
                Role = nutritionistRole
            };
            patientUser = new User
            {
                Id = 2,
                Role = patientRole
            };

            diet = new Diet
            {
                Id = 1,
                Description = "Una dieta",
                Title = "Dieta 1"
            };
            
            sessionDetail = new SessionDetail
            {
                Id = 1,
                Session = session,
                User = patientUser
            };
            
            session = new Session
            {
                Id = 1,
                Diets = new List<Diet> {diet},
                Link = "link",
                User = nutritionistUser,
                SessionDetails = new List<SessionDetail>{ sessionDetail }
            };

            progress = new Progress
            {
                Id = 1,
                Description = "Una descripción",
                Session = session
            };
        }
        
        [When(@"he goes to patient section")]
        public void WhenNutritionistGoesToPatientSection()
        {
            //Arrange
            sessionRepositoryMock.Setup(r => r.ListByUserIdAsync(nutritionistUser.Id))
                .ReturnsAsync(new List<Session> { session });

            sessionService = new SessionService(sessionRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he clicks into a patient")]
        public void WhenNutritionistClicksIntoAPatient()
        {
            //Arrange
            sessionRepositoryMock.Setup(r => r.FindById(nutritionistUser.Id))
                .ReturnsAsync(session);

            sessionService = new SessionService(sessionRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he clicks into report advances")]
        public void WhenNutritionistClicksIntoReportAdvances()
        {
            //Arrange
            progressRepositoryMock.Setup(r => r.ListBySessionIdAsync(session.Id))
                .ReturnsAsync(new List<Progress>{progress});

            progressService = new ProgressService(progressRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [When(@"he clicks on save report")]
        public void WhenNutritionistClicksOnSaveReport()
        {
            //Arrange
            progressRepositoryMock.Setup(r => r.AddAsync(progress));

            progressService = new ProgressService(progressRepositoryMock.Object, unitofworkMock.Object);
        }
        
        [Then(@"the system should show which patients had an appointment and their data")]
        public async void ThenTheSystemShouldShowTheDietListUploadedToThePlatformByHim()
        {
            var response = await sessionService.ListByUserIdAsync(nutritionistUser.Id);
            response.Count().Should().Be(1);
        }
        
        [Then(@"the system should show detailed data from the patient and its respective appointments")]
        public async void ThenTheSystemShouldShowDetailedDataFromThePatient()
        {
            var response = await sessionService.GetByIdAsync(nutritionistUser.Id);
            response.Should().Be(nutritionistUser);
        }
        
        [Then(@"the system should show a form where it should fill advances and future recomendations")]
        public async void ThenTheSystemShouldShowAFromWhereItShouldFillAdvances()
        {
            var response = await progressService.ListBySessionIdAsync(session.Id);
            response.Count().Should().Be(1);
        }
        
        [Then(@"the system should save the report in the data base for the patient to check it")]
        public async void ThenTheSystemShouldSaveTheReportInTheDatabase()
        {
            var response = await progressService.SaveAsync(progress);
            response.Success.Should().BeTrue();
        }
        
        [Then(@"the system should save the report in the data base but the patient will not be able to check it")]
        public async void ThenTheSystemShouldSaveTheReportInTheDatabaseButPatientNoAble()
        {
            var response = await progressService.SaveAsync(progress);
            response.Success.Should().BeTrue();
        }
    }
}
