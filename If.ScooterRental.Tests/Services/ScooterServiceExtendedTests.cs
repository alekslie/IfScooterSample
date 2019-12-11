using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using If.ScooterRental.Services;
using If.ScooterRental.Models;

namespace If.ScooterRental.Tests.Services
{
	public class ScooterServiceExtendedTests
	{
		private Mock<ILogger<ScooterService>> _mockLogger;
		private ScooterService _scooterService;

		public ScooterServiceExtendedTests()
		{
			_mockLogger = new Mock<ILogger<ScooterService>>();
			_scooterService = new ScooterService(_mockLogger.Object);
		}

		[Theory]
		[ClassData(typeof(SetRentalScooterWrongArgData))]
		public void SetRentalStatusWrongArguments(string expectedArgument, string scooterId)
		{
			Assert.Throws<ArgumentException>(expectedArgument, () => _scooterService.SetRentalStatus(scooterId, true));
		}


		[Fact]
		public void SetRentalStatusScooterExist()
		{
			string id = "setRental_34_abc001";
			decimal price = 0.05M;
			bool status = true;

			_scooterService.AddScooter(id, price);
			_scooterService.SetRentalStatus(id, status);
			Scooter scooter = _scooterService.GetScooterById(id);
			Assert.Equal(scooter.Id, id);
			Assert.Equal(scooter.IsRented, status);
		}

		[Fact]
		public void SetRentalStatusScooterNotExist()
		{
			string id = "setRental_35_abc001";
			bool status = true;

			Assert.Throws<ScooterServiceException>(() => _scooterService.SetRentalStatus(id, status));
		}
	}
}
