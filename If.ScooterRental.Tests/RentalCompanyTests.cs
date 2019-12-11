using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using If.ScooterRental.Services;
using If.ScooterRental.Models;

namespace If.ScooterRental.Tests
{
	public class RentalCompanyTests
	{
		private readonly Mock<ILogger<RentalCompany>> _mockLogger = new Mock<ILogger<RentalCompany>>();
		private readonly Mock<IScooterService> _mockScooterService = new Mock<IScooterService>();
		private readonly RentalCompany _rentalCompany;
		private readonly string _name = "IfRentalCompany";

		public RentalCompanyTests()
		{
			_rentalCompany = new RentalCompany(_mockLogger.Object, _mockScooterService.Object, _name);
		}

		[Fact]
		public void CreateCompany()
		{
			Assert.Throws<ArgumentNullException>("logger", () => new RentalCompany(null, _mockScooterService.Object, _name));
			Assert.Throws<ArgumentNullException>("scooterService", () => new RentalCompany(_mockLogger.Object, null, _name));
			Assert.Throws<ArgumentNullException>("name", () => new RentalCompany(_mockLogger.Object, _mockScooterService.Object, null));
			Assert.Equal(_name, _rentalCompany.Name);
		}

	}
}
