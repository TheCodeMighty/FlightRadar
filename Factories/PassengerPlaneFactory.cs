using OOD_Project1.Entities;
using System.Globalization;

namespace OOD_Project1
{
    public class PassengerPlaneFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new PassengerPlane(
                data[0],
                ulong.Parse(data[1]),
                data[2],
                data[3],
                data[4],
                ushort.Parse(data[5]),
                ushort.Parse(data[6]),
                ushort.Parse(data[7]));
        }

        public override void AddEntity(EntityStorage storage,BaseEntity entity)
        {
            if (entity is PassengerPlane passengerPlane)
            {
                storage.PassengerPlanes.Add(passengerPlane);
            }
        }
    }
}
