using System;

namespace If.ScooterRental
{
    public class RentalCompany : IRentalCompany
    {
        public string Name => throw new NotImplementedException();

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
