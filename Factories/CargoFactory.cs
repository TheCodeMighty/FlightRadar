using OOD_Project1.Entities;
using System.Globalization;

namespace OOD_Project1
{
    public class CargoFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new Cargo(
                data[0],
                ulong.Parse(data[1]),
                float.Parse(data[2], CultureInfo.InvariantCulture),
                data[3],
                data[4]);
        }

        public override void AddEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Cargo cargo)
            {
                storage.Cargos.Add(cargo);
            }
        }
    }
}
