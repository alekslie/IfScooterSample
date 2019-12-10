using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Text;
using If.ScooterRental.Models;

namespace If.ScooterRental.Services
{
    public class ScooterService : IScooterService
    {
        private readonly ILogger<ScooterService> _logger;

        public ScooterService(ILogger<ScooterService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddScooter(string scooterId, decimal pricePerMinute)
        {
            if (String.IsNullOrEmpty(scooterId) || scooterId.Length < 5)
                throw new ArgumentException("Parameter cannot be null or less than 5 characters.", nameof(scooterId));
            if (pricePerMinute < 0)
                throw new ArgumentException("Parameter cannot be negative.", nameof(pricePerMinute));

            throw new NotImplementedException();
        }

        public Scooter GetScooterById(string scooterId)
        {
            throw new NotImplementedException();
        }

        public IList<Scooter> GetScooters()
        {
            throw new NotImplementedException();
        }

        public void RemoveScooter(string scooterId)
        {
            throw new NotImplementedException();
        }
    }
}
