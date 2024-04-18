using FlightRadar.Entities;

namespace FlightRadar
{
    public class DataLoader
    {
        public static Dictionary<string, EntityFactory> factoryMap = new Dictionary<string, EntityFactory>()
        {
            { "C", new CrewFactory() },
            { "P", new PassengerFactory() },
            { "CA", new CargoFactory() },
            { "CP", new CargoPlaneFactory() },
            { "PP", new PassengerPlaneFactory() },
            { "AI", new AirportFactory() },
            { "FL", new FlightFactory() }
        };

        public static EntityStorage LoadData(string fileName)
        {
            string filePath = FilePathFinder.FindFilePath(fileName);
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                BaseEntity entity = factoryMap[parts[0]].CreateEntity(parts);              
                if (entity != null)
                {
                    factoryMap[parts[0]].AddEntity(EntityStorage.GetInstance(), entity);
                }
            }

            return EntityStorage.GetInstance();
        }
    }
}
