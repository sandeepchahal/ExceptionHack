IHouseBuilder basicBuilder = new BasicHouseBuilder();
Architect architect = new Architect(basicBuilder);
architect.ConstructHouse();
House basicHouse = basicBuilder.GetHouse();
Console.WriteLine(basicHouse.NumberOfRooms);

IHouseBuilder luxuryBuilder = new LuxuryHouseBuilder();
Architect luxuryArchitect = new Architect(luxuryBuilder);
luxuryArchitect.ConstructHouse();
House luxuryHouse = luxuryBuilder.GetHouse();
Console.WriteLine(luxuryHouse);