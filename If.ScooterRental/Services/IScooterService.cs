using System.Collections.Generic;
using If.ScooterRental.Models;

namespace If.ScooterRental.Services
{
    public interface IScooterService
    {
        /// <summary> 
        /// Add scooter. 
        /// </summary> 
        /// <param name="scooterId">Unique ID of the scooter</param> 
        /// <param name="pricePerMinute">Rental price of the scooter per one minute</param> 
        void AddScooter(string scooterId, decimal pricePerMinute);

        /// <summary> 
        /// Remove scooter. 
        /// This action is not allowed for scooters if the rental is in progress.
        /// </summary>
        /// <param name="scooterId">Unique ID of the scooter</param>
        void RemoveScooter(string scooterId);

        /// <summary>  
        /// List of scooters that belong to the company. 
        /// </summary> 
        /// <returns>Return a list of available scooters.</returns> 
        IList<Scooter> GetScooters();

        /// <summary> 
        /// Get particular scooter by ID. 
        /// </summary> 
        /// <param name="scooterId">Unique ID of the scooter.</param> 
        /// <returns>Return a particular scooter.</returns> 
        Scooter GetScooterById(string scooterId);

        /// <summary>
        /// Sets scooter rental status.
        /// </summary>
        /// <param name="scooterId">Unique ID of the scooter</param> 
        /// <param name="isRented">Value of the status.</param>
        void SetRentalStatus(string scooterId, bool isRented);
    }
}
