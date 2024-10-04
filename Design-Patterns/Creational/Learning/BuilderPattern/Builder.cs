public class House
{
    public int NumberOfRooms { get; set; }
    public string RoofType { get; set; }
    public bool HasGarage { get; set; }
    public bool HasGarden { get; set; }
}

public interface IHouseBuilder
{
    void SetNumberOfRooms(int numberOfRooms);
    void SetRoofType(string roofType);
    void SetGarage(bool hasGarage);
    void SetGarden(bool hasGarden);
    House GetHouse();
}

public interface IHouseWithPoolBuilder
{
    void AddSwimmingPool(bool hasPool);
}

public interface IHouseWithTheaterBuilder
{
    void AddHomeTheater(bool hasTheater);
}


public class BasicHouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void SetNumberOfRooms(int numberOfRooms) => _house.NumberOfRooms = numberOfRooms;
    public void SetRoofType(string roofType) => _house.RoofType = roofType;
    public void SetGarage(bool hasGarage) => _house.HasGarage = hasGarage;
    public void SetGarden(bool hasGarden) => _house.HasGarden = hasGarden;
    public House GetHouse() => _house;
}

public class LuxuryHouseBuilder : IHouseBuilder, IHouseWithPoolBuilder, IHouseWithTheaterBuilder
{
    private House _house = new House();

    public void SetNumberOfRooms(int numberOfRooms) => _house.NumberOfRooms = numberOfRooms;
    public void SetRoofType(string roofType) => _house.RoofType = roofType;
    public void SetGarage(bool hasGarage) => _house.HasGarage = hasGarage;
    public void SetGarden(bool hasGarden) => _house.HasGarden = hasGarden;
    public void AddSwimmingPool(bool hasPool) => _house.HasGarden = hasPool; // Simplified for demo
    public void AddHomeTheater(bool hasTheater) { /* Implementation */ }
    public House GetHouse() => _house;
}

public class Architect
{
    private IHouseBuilder _houseBuilder;

    public Architect(IHouseBuilder houseBuilder)
    {
        _houseBuilder = houseBuilder;
    }

    public void ConstructHouse()
    {
        _houseBuilder.SetNumberOfRooms(3);
        _houseBuilder.SetRoofType("Gabled");
        _houseBuilder.SetGarage(true);
        _houseBuilder.SetGarden(true);

        if (_houseBuilder is IHouseWithPoolBuilder poolBuilder)
        {
            poolBuilder.AddSwimmingPool(true);
        }

        if (_houseBuilder is IHouseWithTheaterBuilder theaterBuilder)
        {
            theaterBuilder.AddHomeTheater(true);
        }
    }
}


