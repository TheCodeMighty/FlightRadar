namespace FlightRadar
{
    public class Cargo : BaseEntity
    {
        public float Weight { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public Cargo(string identifier, ulong id, float weight, string code, string description) : base(identifier, id)
        {
            Weight = weight;
            Code = code;
            Description = description;
        }
    }
}
