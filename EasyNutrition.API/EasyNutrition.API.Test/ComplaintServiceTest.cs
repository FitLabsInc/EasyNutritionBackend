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
    public class ComplaintServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoComplaintsReturnsEmptyCollection()
        {
            var mockComplaintRepository = GetDefaultIComplaintRepositoryInstance();
            mockComplaintRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Complaint>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ComplaintService(
                mockComplaintRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Complaint> result = (List<Complaint>)await service.ListAsync();
            int complaintsCount = result.Count;

            // Assert
            complaintsCount.Should().Equals(0);
        }


        private Mock<IComplaintRepository> GetDefaultIComplaintRepositoryInstance()
        {
            return new Mock<IComplaintRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}