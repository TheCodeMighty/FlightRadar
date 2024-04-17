using OOD_Project1.Entities;

namespace OOD_Project1
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
