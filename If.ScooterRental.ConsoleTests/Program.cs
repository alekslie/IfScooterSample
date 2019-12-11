using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


using If.ScooterRental.Services;

namespace If.ScooterRental.ConsoleTests
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create all services for dependency injection.
			var services = new ServiceCollection()
				.AddLogging(configure => configure.AddConsole().SetMinimumLevel(LogLevel.Warning))
				.AddSingleton<ScooterService>()
				.AddRentalCompany("IfRentalCompany");

			string id = "MuScooterId001";
			using (ServiceProvider provider = services.BuildServiceProvider())
			{
				try
				{
					// Create rental company with dependency injection services.
					RentalCompany rentalCompany = provider.GetService<RentalCompany>();
					string name = rentalCompany.Name;

					ScooterService scooterService = provider.GetService<ScooterService>();
					scooterService.AddScooter(id, 100.10m);
					scooterService.AddScooter("hi999", 10.10m);
					scooterService.SetRentalStatus(id, true);
					var allScooters = scooterService.GetScooters();

					var scooter = scooterService.GetScooterById(id);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception in service: {ex.Message}");
				}
				Console.ReadLine();
			}
		}
	}
}
