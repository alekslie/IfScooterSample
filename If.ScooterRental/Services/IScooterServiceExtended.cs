namespace If.ScooterRental.Services
{
    public interface IScooterServiceExtended
    {
        /// <summary>
        /// Sets scooter rental status.
        /// </summary>
        /// <param name="scooterId">Unique ID of the scooter</param> 
        /// <param name="isRented">Value of the status.</param>
        void SetRentalStatus(string scooterId, bool isRented);

    }
}
