using System.Text.Json.Serialization;

namespace OOD_Project1
{
    [JsonDerivedType(typeof(Passenger))]
    [JsonDerivedType(typeof(Airport))]
    [JsonDerivedType(typeof(PassengerPlane))]
    [JsonDerivedType(typeof(Crew))]
    [JsonDerivedType(typeof(Cargo))]
    [JsonDerivedType(typeof(CargoPlane))]
    [JsonDerivedType(typeof(Flight))]
    public class BaseEntity
    {
        public ulong ID { get; set; }
        public string Identifier { get; set; } = "";

        public BaseEntity(string identifier, ulong id)
        {
            Identifier = identifier;
            ID = id;
        }
    }
}
