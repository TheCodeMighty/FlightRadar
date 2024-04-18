using FlightRadar.Entities;

namespace FlightRadar.MessageParsers
{
    public class PassengerPlaneParser : MessageParser
    {
        public override BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            string serial = System.Text.Encoding.ASCII.GetString(data, 15, 10).TrimEnd('\0');

            string countryISO = System.Text.Encoding.ASCII.GetString(data, 25, 3);

            ushort modelLength = BitConverter.ToUInt16(data, 28);
            string model = System.Text.Encoding.ASCII.GetString(data, 30, modelLength);

            ushort firstClassSize = BitConverter.ToUInt16(data, 30 + modelLength);

            ushort businessClassSize = BitConverter.ToUInt16(data, 32 + modelLength);

            ushort economyClassSize = BitConverter.ToUInt16(data, 34 + modelLength);

            return new PassengerPlane(identifier, id, serial, countryISO, model, firstClassSize, businessClassSize, economyClassSize);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is PassengerPlane passengerPlane)
            {
                storage.PassengerPlanes.Add(passengerPlane);
            }
        }
    }
}
