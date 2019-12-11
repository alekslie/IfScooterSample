using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using If.ScooterRental.Services;

namespace If.ScooterRental.ConsoleTests
{
	public static class ServiceCollectionExtentions
	{
        public static IServiceCollection AddRentalCompany(this IServiceCollection services, string name)
        {
            var provider = services.BuildServiceProvider();
            services.AddSingleton<RentalCompany>(s =>
                new RentalCompany(provider.GetService<ILogger<RentalCompany>>(), provider.GetService<ScooterService>(), name));
            return services;
        }
    }
}
