using FlightRadar.Entities;

namespace FlightRadar
{
    public abstract class EntityFactory
    {
        public virtual BaseEntity CreateEntity(string[] data)
        {
            return new BaseEntity(data[0], ulong.Parse(data[1]));
        }
        public EntityFactory() { }

        public virtual void AddEntity(EntityStorage storage, BaseEntity entity){}
    }
}
