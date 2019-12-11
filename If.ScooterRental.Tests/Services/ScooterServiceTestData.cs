using System.Collections.Generic;
using Xunit;

namespace If.ScooterRental.Tests.Services
{
    public class AddScooterWrongArgData : TheoryData<string, string, decimal>
    {
        public AddScooterWrongArgData()
        {
            Add("scooterId", "", 13.30M);
            Add("pricePerMinute", "455667gsqqa", -2.30M);
            Add("scooterId", "", -2.30M);
            Add("scooterId", null, 2.30M);
            Add("scooterId", null, 0M);
            Add("scooterId", "455", -200M);
            Add("pricePerMinute", "55559", -0.001M);
        }
    }

    public class AddScooterNotExistsData : TheoryData<string, decimal>
    {
        public AddScooterNotExistsData()
        {
            Add("add01_abc001", 0.05M);
            Add("add01_abc002", 0.05M);
            Add("add01_abc003", 0.05M);
            Add("add01_abc004", 0.30M);
            Add("add01_abc005", 0.30M);
        }
    }

    public class AddScooterSameAlreadyExistsData : TheoryData<string, decimal>
    {
        public AddScooterSameAlreadyExistsData()
        {
            Add("add02_abc001", 0.05M);
            Add("add02_abc002", 0.05M);
        }
    }

    public class RemoveGetScooterWrongArgData : TheoryData<string, string>
    {
        public RemoveGetScooterWrongArgData()
        {
            Add("scooterId", "");
            Add("scooterId", null);
            Add("scooterId", "455");
            Add("scooterId", "    ");
        }
    }



    public class GetScooterWhenExistsData : TheoryData<string, decimal>
    {
        public GetScooterWhenExistsData()
        {
            Add("get01_abc001", 0.05M);
            Add("get01_abc002", 0.05M);
            Add("get01_abc003", 0.05M);
            Add("get01_abc004", 0.05M);
        }
    }

    public class GetScooterWhenNotExistsData : TheoryData<string>
    {
        public GetScooterWhenNotExistsData()
        {
            Add("get02_abc001");
            Add("get02_abc002");
            Add("get02_abc003");
            Add("get02_abc004");
            Add("get02_abc005");
        }
    }

    public class GetAllScootersData : TheoryData<string, decimal>
    {
        Dictionary<string, decimal> _scooters = new Dictionary<string, decimal>();
        public GetAllScootersData()
        {
            _scooters.Add("get03_abc001", 0.05M);
            _scooters.Add("get03_abc002", 0.05M);
            _scooters.Add("get03_abc003", 0.05M);
            _scooters.Add("get03_abc004", 0.05M);
            _scooters.Add("get03_abc005", 0.05M);
            _scooters.Add("get03_abc006", 0.05M);
            _scooters.Add("get03_abc007", 0.05M);
            _scooters.Add("get03_abc008", 0.05M);
        }
        public Dictionary<string, decimal> Scooters {  get { return _scooters; } }
    }
}
