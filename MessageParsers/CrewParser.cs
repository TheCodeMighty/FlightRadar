using FlightRadar.Entities;

namespace FlightRadar.MessageParsers
{
    public class CrewParser : MessageParser
    {
        public override BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            ushort nameLength = BitConverter.ToUInt16(data, 15);
            string name = System.Text.Encoding.ASCII.GetString(data, 17, nameLength);

            ushort age = BitConverter.ToUInt16(data, 17 + nameLength);

            string phone = System.Text.Encoding.ASCII.GetString(data, 19 + nameLength, 12);

            ushort emailLength = BitConverter.ToUInt16(data, 31 + nameLength);
            string email = System.Text.Encoding.ASCII.GetString(data, 33 + nameLength, emailLength);

            ushort practice = BitConverter.ToUInt16(data, 33 + nameLength + emailLength);

            string role = System.Text.Encoding.ASCII.GetString(data, 35 + nameLength + emailLength, 1);

            return new Crew(identifier, id, name, age, phone, email, practice, role);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Crew crew)
            {
                storage.Crews.Add(crew);
            }
        }
    }
}
