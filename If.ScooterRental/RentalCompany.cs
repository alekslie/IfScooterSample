using System;
using Microsoft.Extensions.Logging;
using If.ScooterRental.Services;

namespace If.ScooterRental
{
    public class RentalCompany : IRentalCompany
    {
        private readonly ILogger<RentalCompany> _logger;
        private readonly IScooterService _scooterService;
        private readonly string _name;

        public RentalCompany(ILogger<RentalCompany> logger, IScooterService scooterService, string name)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scooterService = scooterService ?? throw new ArgumentNullException(nameof(scooterService));
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Name { get { return _name; } }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            throw new NotImplementedException();
        }

        public decimal EndRent(string id)
        {
            throw new NotImplementedException();
        }

        public void StartRent(string id)
        {
            throw new NotImplementedException();
        }
    }
}
