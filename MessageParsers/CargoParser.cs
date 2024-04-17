using OOD_Project1.Entities;

namespace OOD_Project1.MessageParsers
{
    public class CargoParser : MessageParser
    {
        public override BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            float weight = BitConverter.ToSingle(data, 15);

            string code = System.Text.Encoding.ASCII.GetString(data, 19, 6);

            ushort descriptionLength = BitConverter.ToUInt16(data, 25);

            string description = System.Text.Encoding.ASCII.GetString(data, 27, descriptionLength);

            return new Cargo(identifier, id, weight, code, description);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Cargo cargo)
            {
                storage.Cargos.Add(cargo);
            }
        }

    }
}
