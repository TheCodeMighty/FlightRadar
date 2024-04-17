using OOD_Project1.Entities;

namespace OOD_Project1.MessageParsers
{
    public class CargoPlaneParser : MessageParser
    {
        public override BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            string serial = System.Text.Encoding.ASCII.GetString(data, 15, 10).TrimEnd('\0');

            string countryISO = System.Text.Encoding.ASCII.GetString(data, 25, 3);

            ushort modelLength = BitConverter.ToUInt16(data, 28);
            string model = System.Text.Encoding.ASCII.GetString(data, 30, modelLength);

            float maxLoad = BitConverter.ToSingle(data, 30 + modelLength);

            return new CargoPlane(identifier, id, serial, countryISO, model, maxLoad);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is CargoPlane cargoPlane)
            {
                storage.CargoPlanes.Add(cargoPlane);
            }
        }
    }
}
