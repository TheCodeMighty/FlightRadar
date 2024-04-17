using OOD_Project1.Entities;

namespace OOD_Project1
{
    public class CrewFactory : EntityFactory
    {
        public override BaseEntity CreateEntity(string[] data)
        {
            return new Crew(
                data[0],
                ulong.Parse(data[1]),
                data[2],
                ulong.Parse(data[3]),
                data[4],
                data[5],
                ushort.Parse(data[6]),
                data[7]);
        }

        public override void AddEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Crew crew)
            {
                storage.Crews.Add(crew);
            }
        }
    }
}