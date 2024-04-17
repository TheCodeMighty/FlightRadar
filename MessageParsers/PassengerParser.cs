using OOD_Project1.Entities;

namespace OOD_Project1.MessageParsers
{
    public class PassengerParser : MessageParser
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

            string _class = System.Text.Encoding.ASCII.GetString(data, 33 + nameLength + emailLength, 1);

            ulong miles = BitConverter.ToUInt64(data, 34 + nameLength + emailLength);

            return new Passenger(identifier, id, name, age, phone, email, _class, miles);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Passenger passenger)
            {
                storage.Passengers.Add(passenger);
            }
        }
    }
}
