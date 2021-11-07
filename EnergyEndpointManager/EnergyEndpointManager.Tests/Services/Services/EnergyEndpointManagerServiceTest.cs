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
            service.InsertEndpoint("X001", 17, 200, "1.00.1", 0);
            repositoryMock.Verify(s => s.Insert(It.IsAny<EnergyEndpoint>()), Times.Once);
        }

        [Test]
        public void ShouldCallRepositoryEdit()
        {
            var serialNumber = "X001";

            service.EditEndpoint(serialNumber, 0);

            repositoryMock.Verify(s => s.Get(serialNumber), Times.Once);
            repositoryMock.Verify(s => s.Edit(serialNumber, It.IsAny<EnergyEndpoint>()), Times.Once);
        }

        [Test]
        public void ShouldCallRepositoryDelete()
        {
            var serialNumber = "X001";

            service.DeleteEndpoint(serialNumber);

            repositoryMock.Verify(s => s.Delete(serialNumber), Times.Once);
        }

        [Test]
        public void ShouldCallRepositoryGet()
        {
            var serialNumber = "X001";

            var energyEndpointViewModel = service.FindEndpoint(serialNumber);

            repositoryMock.Verify(s => s.Get(serialNumber), Times.Once);
            Assert.IsNotNull(energyEndpointViewModel);
        }

        [Test]
        public void ShouldCallRepositoryGetAll()
        {
            var endpointViewModels = service.ListEndpoints();

            repositoryMock.Verify(s => s.GetAll(), Times.Once);
            Assert.Greater(endpointViewModels.Count, 0);
        }
    }
}