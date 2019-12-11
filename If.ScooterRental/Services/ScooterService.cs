using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using If.ScooterRental.Models;

namespace If.ScooterRental.Services
{
    /// <summary>
    /// Implements scooter service.
    /// </summary>
    public class ScooterService : IScooterService
    {
        private readonly ILogger<ScooterService> _logger;
        private readonly Dictionary<string, Scooter> _scooterRepository = new Dictionary<string, Scooter>();

        public ScooterService(ILogger<ScooterService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddScooter(string scooterId, decimal pricePerMinute)
        {
            ValidateId(scooterId);

            if (pricePerMinute < 0)
            {
                _logger.LogWarning($"Add scooter with id:{scooterId}, minute price is negative");
                throw new ArgumentException("Parameter cannot be negative.", nameof(pricePerMinute));
            }

            // Accept if identical exists.
            if (!_scooterRepository.ContainsKey(scooterId))
            {
                _scooterRepository.Add(scooterId, new Scooter(scooterId, pricePerMinute));
                _logger.LogInformation($"Scooter added, id:{scooterId}, price per minute:{pricePerMinute}");
            }
            else
            {
                if (_scooterRepository[scooterId].PricePerMinute != pricePerMinute)
                {
                    _logger.LogWarning($"Scooter with id:{scooterId} exists but minute price is " +
                        $"different:existing/{_scooterRepository[scooterId].PricePerMinute} vs new:{pricePerMinute}");
                    throw new ScooterServiceException($"Scooter id:{scooterId} already exists with different minute price.");
                }
                else
                {
                    _logger.LogInformation($"Scooter with id:{scooterId} and price per minute:{pricePerMinute} alredy exists.");
                }
            }
         }

        public Scooter GetScooterById(string scooterId)
        {
            ValidateId(scooterId);

            if (_scooterRepository.ContainsKey(scooterId))
            {
                _logger.LogInformation($"Scooter found, id:{scooterId}");
                return _scooterRepository[scooterId];
            }
            else
                return null;
        }

        public IList<Scooter> GetScooters()
        {
            _logger.LogInformation($"All scooter list returned. Total count:{_scooterRepository.Count}");
            return _scooterRepository.Values.ToList();
        }

        public void RemoveScooter(string scooterId)
        {
            ValidateId(scooterId);

            if (_scooterRepository.ContainsKey(scooterId))
            {
                _scooterRepository.Remove(scooterId);
                _logger.LogInformation($"Scooter removed, id:{scooterId}");
            }
            else
            {
                _logger.LogInformation($"Scooter with id:{scooterId} does not exist.");
            }
        }

        public void SetRentalStatus(string scooterId, bool isRented)
        {
            ValidateId(scooterId);

            if (_scooterRepository.ContainsKey(scooterId))
            {
                _scooterRepository[scooterId].IsRented = isRented;
                _logger.LogInformation($"Scooter id:{scooterId} rental status set to:{isRented}");
            }
            else
            {
                _logger.LogWarning($"Cannot set status. Scooter with id:{scooterId} does not exist.");
                throw new ScooterServiceException($"Scooter id:{scooterId} does not exist.");
            }
        }

        private void  ValidateId(string scooterId)
        {
            if (String.IsNullOrEmpty(scooterId) || scooterId.Length < 5)
                throw new ArgumentException("Parameter cannot be null or less than 5 characters.", nameof(scooterId));
        }
    }
}
