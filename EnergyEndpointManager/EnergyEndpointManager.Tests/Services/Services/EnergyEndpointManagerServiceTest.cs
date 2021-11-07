using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using EnergyEndpointManager.Repository.Interfaces;
using EnergyEndpointManager.Services.Builders;
using EnergyEndpointManager.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EnergyEndpointManager.Tests.Services.Services
{
    public class EnergyEndpointManagerServiceTest
    {
        private Mock<IEnergyEndpointManagerRepository> repositoryMock;
        private IEnergyEndpointManagerService service;

        [SetUp]
        public void Setup()
        {
            var energyEndpoint = new EnergyEndpoint("", MeterModelEnum.NSX1P2W, 0, "", SwitchStateEnum.Disconnected);

            repositoryMock = new Mock<IEnergyEndpointManagerRepository>();
            repositoryMock.Setup(s => s.Get(It.IsAny<string>())).Returns(energyEndpoint);
            repositoryMock.Setup(s => s.GetAll()).Returns(new List<EnergyEndpoint> { energyEndpoint });

            service = EnergyEndpointManagerServiceBuilder.Build(repositoryMock.Object);
        }

        [Test]
        public void ShouldCallRepositoryInsert()
        {
            var response = service.InsertEndpoint("X001", 17, 200, "1.00.1", 0);
            repositoryMock.Verify(s => s.Insert(It.IsAny<EnergyEndpoint>()), Times.Once);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void ShouldCallRepositoryEdit()
        {
            var serialNumber = "X001";

            var response = service.EditEndpoint(serialNumber, 0);

            repositoryMock.Verify(s => s.Get(serialNumber), Times.Once);
            repositoryMock.Verify(s => s.Edit(serialNumber, It.IsAny<EnergyEndpoint>()), Times.Once);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void ShouldCallRepositoryDelete()
        {
            var serialNumber = "X001";

            var response = service.DeleteEndpoint(serialNumber);

            repositoryMock.Verify(s => s.Delete(serialNumber), Times.Once);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void ShouldCallRepositoryGet()
        {
            var serialNumber = "X001";

            var response = service.FindEndpoint(serialNumber);

            repositoryMock.Verify(s => s.Get(serialNumber), Times.Once);
            Assert.IsNotNull(response.EnergyEndpoint);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void ShouldCallRepositoryGetAll()
        {
            var response = service.ListEndpoints();

            repositoryMock.Verify(s => s.GetAll(), Times.Once);
            Assert.Greater(response.EnergyEndpoints.Count, 0);
            Assert.IsTrue(response.Success);
        }
    }
}