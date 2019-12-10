﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using If.ScooterRental.Services;
using If.ScooterRental.Models;

namespace If.ScooterRental.Tests.Services
{
    public class ScooterServiceTests
    {
        private Mock<ILogger<ScooterService>> _mockLogger;
        private IScooterService _scooterService;

        public ScooterServiceTests()
        {
            _mockLogger = new Mock<ILogger<ScooterService>>();
            _scooterService = new ScooterService(_mockLogger.Object);
        }

        [Fact]
        public void CreateService()
        {
            Assert.Throws<ArgumentNullException>("logger", () => new ScooterService(null));
        }

        [Theory]
        [ClassData(typeof(AddScooterWrongArgData))]
        public void AddScooterWrongArguments(string expectedArgument, string scooterId, decimal pricePerMinute)
        {
            Assert.Throws<ArgumentException>(expectedArgument, () => _scooterService.AddScooter(scooterId, pricePerMinute));
        }

        [Theory]
        [ClassData(typeof(AddScooterNotExistsData))]
        public void AddScooterNotExistsData(string scooterId, decimal pricePerMinute)
        {
            _scooterService.AddScooter(scooterId, pricePerMinute);
            Scooter scooter = _scooterService.GetScooterById(scooterId);
            Assert.Equal(scooter.Id, scooterId);
            Assert.Equal(scooter.PricePerMinute, pricePerMinute);
        }

        [Theory]
        [ClassData(typeof(AddScooterSameAlreadyExistsData))]
        public void AddScooterSameAlreadyExist(string scooterId, decimal pricePerMinute)
        {
            _scooterService.AddScooter(scooterId, pricePerMinute);
            Scooter scooter = _scooterService.GetScooterById(scooterId);
            Assert.Equal(scooter.Id, scooterId);
            Assert.Equal(scooter.PricePerMinute, pricePerMinute);
            _scooterService.AddScooter(scooterId, pricePerMinute);
        }

        [Fact]
        public void AddScooterDifferentAlreadyExist()
        {
            string id = "adddiff03_abc001";
            decimal price1 = 0.05M;
            decimal price2 = 0.07M;
            _scooterService.AddScooter(id, price1);
            Scooter scooter = _scooterService.GetScooterById(id);
            Assert.Equal(scooter.Id, id);
            Assert.Equal(scooter.PricePerMinute, price1);
            Assert.Throws<ScooterServiceException>(() => _scooterService.AddScooter(id, price2));
        }

        [Fact]
        public void RemoveScooter()
        {
            string id = "rem01_abc001";
            decimal price = 0.05M;

            // When exists.
            _scooterService.AddScooter(id, price);
            Scooter scooter = _scooterService.GetScooterById(id);
            Assert.Equal(scooter.Id, id);
            Assert.Equal(scooter.PricePerMinute, price);
            _scooterService.RemoveScooter(id);
            scooter = _scooterService.GetScooterById(id);
            Assert.Null(scooter);

            // When does not exist such id.
            _scooterService.RemoveScooter(id);
            scooter = _scooterService.GetScooterById(id);
            Assert.Null(scooter);
        }

        [Theory]
        [ClassData(typeof(GetScooterWhenExistsData))]
        public void GetScooterWhenExists(string scooterId, decimal pricePerMinute)
        {
            _scooterService.AddScooter(scooterId, pricePerMinute);
            Scooter scooter = _scooterService.GetScooterById(scooterId);
            Assert.Equal(scooter.Id, scooterId);
            Assert.Equal(scooter.PricePerMinute, pricePerMinute);
         }

        [Theory]
        [ClassData(typeof(GetScooterWhenNotExistsData))]
        public void GetScooterWhenNotExists(string scooterId)
        {
            Scooter scooter = _scooterService.GetScooterById(scooterId);
            Assert.Null(scooter);
        }

        [Fact]
        public void GetAllScooters()
        {
            var scootersData = new GetAllScootersData();
            foreach (KeyValuePair<string, decimal> kvp in scootersData.Scooters)
            {
                //_scooterService.AddScooter(kvp.Key, kvp.Value);
            }
            IList<Scooter> resultScooters =_scooterService.GetScooters();
            Assert.Equal(scootersData.Scooters.Count, resultScooters.Count);
  
            foreach (Scooter scooter in resultScooters)
            {
                Assert.True(scootersData.Scooters.ContainsKey(scooter.Id));
                Assert.Equal(scootersData.Scooters[scooter.Id], scooter.PricePerMinute);
            }
        }
    }
}
