using OOD_Project1.Entities;

namespace OOD_Project1.MessageParsers
{
    public class MessageParser
    {
        public virtual BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            return new BaseEntity(identifier, id);
        }

        public virtual void AddParsedEntity(EntityStorage storage, BaseEntity entity) { }
    }
}
