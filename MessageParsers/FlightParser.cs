using OOD_Project1.Entities;

namespace OOD_Project1.MessageParsers
{
    public class FlightParser : MessageParser
    {
        public override BaseEntity MessageParsing(byte[] data)
        {
            string identifier = System.Text.Encoding.ASCII.GetString(data, 0, 3);

            ulong id = BitConverter.ToUInt64(data, 7);

            ulong originID = BitConverter.ToUInt64(data, 15);

            ulong targetID = BitConverter.ToUInt64(data, 23);

            long _takeOffTime = BitConverter.ToInt64(data, 31);
            DateTimeOffset takeOffDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(_takeOffTime);
            DateTime takeOffTime = takeOffDateTimeOffset.UtcDateTime;

            long _landingTime = BitConverter.ToInt64(data, 39);
            DateTimeOffset landingDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(_landingTime);
            DateTime landingTime = landingDateTimeOffset.UtcDateTime;

            float longitude = 0;
            float latitude = 0;
            float amsl = 0;

            ulong planeID = BitConverter.ToUInt64(data, 47);

            ushort crewCount = BitConverter.ToUInt16(data, 55);
            ulong[] crewIDs = new ulong[crewCount];
            for (int i = 0; i < crewCount; i++)
            {
                crewIDs[i] = BitConverter.ToUInt64(data, 57 + i * 8);
            }

            ushort passengerCount = BitConverter.ToUInt16(data, 57 + 8 * crewCount);
            ulong[] loadIDs = new ulong[passengerCount];
            for (int i = 0; i < passengerCount; i++)
            {
                loadIDs[i] = BitConverter.ToUInt64(data, 59 + 8 * crewCount + i * 8);
            }

            return new Flight(identifier, id, originID, targetID, takeOffTime, landingTime, longitude, latitude, amsl, planeID, crewIDs, loadIDs);
        }

        public override void AddParsedEntity(EntityStorage storage, BaseEntity entity)
        {
            if (entity is Flight flight)
            {
                storage.Flights.Add(flight);
            }
        }
    }
}
