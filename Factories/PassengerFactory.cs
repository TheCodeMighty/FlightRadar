using FlightRadar.Entities;

namespace FlightRadar
{
    public class PassengerFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new Passenger(
                data[0],
                ulong.Parse(data[1]),
                data[2],
                ulong.Parse(data[3]),
                data[4],
                data[5],
                data[6],
                ulong.Parse(data[7]));
        }
        public override void AddEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Passenger passenger)
            {
                storage.Passengers.Add(passenger);
            }
        }
    }
}
