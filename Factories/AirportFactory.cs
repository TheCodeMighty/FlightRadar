using FlightRadar.Entities;
using System.Globalization;

namespace FlightRadar
{
    public class AirportFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new Airport(
                data[0],
                ulong.Parse(data[1]),
                data[2],
                data[3],
                float.Parse(data[4], CultureInfo.InvariantCulture),
                float.Parse(data[5], CultureInfo.InvariantCulture),
                float.Parse(data[6], CultureInfo.InvariantCulture),
                data[7]);
        }

        public override void AddEntity(EntityStorage storage, BaseEntity entity)
        {
            if(entity is Airport airport)
            {
                storage.Airports.Add(airport);
            }
        }
    }
}
