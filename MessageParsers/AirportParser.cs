using OOD_Project1.Entities;

namespace OOD_Project1.MessageParsers
{
    public class AirportParser : MessageParser
    {
        public override BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            ushort nameLength = BitConverter.ToUInt16(data, 15);
            string name = System.Text.Encoding.ASCII.GetString(data, 17, nameLength);

            string code = System.Text.Encoding.ASCII.GetString(data, 17 + nameLength, 3);

            float longitude = BitConverter.ToSingle(data, 20 + nameLength);

            float latitude = BitConverter.ToSingle(data, 24 + nameLength);

            float amsl = BitConverter.ToSingle(data, 28 + nameLength);

            string countryISO = System.Text.Encoding.ASCII.GetString(data, 32 + nameLength, 3);

            return new Airport(identifier, id, name, code, longitude, latitude, amsl, countryISO);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Airport airport)
            {
                storage.Airports.Add(airport);
            }
        }
    }
}
