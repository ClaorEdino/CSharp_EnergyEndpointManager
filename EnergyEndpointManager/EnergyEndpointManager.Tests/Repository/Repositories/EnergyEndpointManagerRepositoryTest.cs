using EnergyEndpointManager.Domain.Domains;
using EnergyEndpointManager.Domain.Enums;
using EnergyEndpointManager.Repository.Builders;
using EnergyEndpointManager.Repository.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace EnergyEndpointManager.Tests.Repository.Repositories
{
    public class EnergyEndpointManagerRepositoryTest
    {
        private IEnergyEndpointManagerRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = EnergyEndpointManagerRepositoryBuilder.Build();
            repository.Insert(new EnergyEndpoint("GTX001", MeterModelEnum.NSX1P2W, 100, "1.00.1", SwitchStateEnum.Disconnected));
            repository.Insert(new EnergyEndpoint("GTX002", MeterModelEnum.NSX1P3W, 200, "1.00.2", SwitchStateEnum.Connected));
            repository.Insert(new EnergyEndpoint("GTX003", MeterModelEnum.NSX2P3W, 300, "1.00.3", SwitchStateEnum.Armed));
            repository.Insert(new EnergyEndpoint("GTX004", MeterModelEnum.NSX3P4W, 400, "1.00.4", SwitchStateEnum.Disconnected));
        }

        [Test]
        public void ShouldBeAbleToInsertAnEndpointOnTheRepository()
        {
            Assert.AreEqual(4, repository.GetAll().Count);
            repository.Insert(new EnergyEndpoint("GTX005", MeterModelEnum.NSX1P2W, 500, "1.00.5", SwitchStateEnum.Connected));
            Assert.AreEqual(5, repository.GetAll().Count);
        }

        [Test]
        public void ShouldBeAbleToGetAllEndpointsFromRepository()
        {
            IList<EnergyEndpoint> endpoints = repository.GetAll();
            Assert.NotZero(endpoints.Count);
        }
    }
}
