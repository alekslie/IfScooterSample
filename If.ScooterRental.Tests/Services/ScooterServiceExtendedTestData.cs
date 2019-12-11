using System.Collections.Generic;
using Xunit;

namespace If.ScooterRental.Tests.Services
{
    public class SetRentalScooterWrongArgData : TheoryData<string, string>
    {
        public SetRentalScooterWrongArgData()
        {
            Add("scooterId", "");
            Add("scooterId", null);
            Add("scooterId", "455");
        }
    }
}
