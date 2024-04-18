using FlightRadar.Entities;
using System.Globalization;

namespace FlightRadar
{
    public class FlightFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new Flight(
                data[0],
                ulong.Parse(data[1]),
                ulong.Parse(data[2]),
                ulong.Parse(data[3]),
                DateTime.Parse(data[4]),
                DateTime.Parse(data[5]),
                float.Parse(data[6], CultureInfo.InvariantCulture),
                float.Parse(data[7], CultureInfo.InvariantCulture),
                float.Parse(data[8], CultureInfo.InvariantCulture),
                ulong.Parse(data[9]),
                data[10].Trim(['[', ']']).Split(';')
                                  .Select(idString => ulong.Parse(idString))
                                  .ToArray(),
                data[11].Trim(['[', ']']).Split(';')
                                      .Select(idString => ulong.Parse(idString))
                                      .ToArray());
        }

        public override void AddEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Flight flight)
            {
                storage.Flights.Add(flight);
            }
        }
    }
}
