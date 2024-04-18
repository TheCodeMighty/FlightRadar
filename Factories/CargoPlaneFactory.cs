using FlightRadar.Entities;
using System.Globalization;

namespace FlightRadar
{
    public class CargoPlaneFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new CargoPlane(
                data[0],
                ulong.Parse(data[1]),
                data[2],
                data[3],
                data[4],
                float.Parse(data[5], CultureInfo.InvariantCulture));
        }

        public override void AddEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is CargoPlane cargoPlane)
            {
                storage.CargoPlanes.Add(cargoPlane);
            }
        }
    }
}