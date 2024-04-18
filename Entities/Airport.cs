namespace FlightRadar
{
    public class Airport : BaseEntity, IReportable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float AMSL { get; set; }
        public string CountryISO { get; set; }

        public string Accept(INewsProviderVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public Airport(string identifier, ulong id, string name, string code, float longitude, float latitude, float amsl, string countyISO) : base(identifier, id)
        {
            Name = name;
            Code = code;
            Longitude = longitude;
            Latitude = latitude;
            AMSL = amsl;
            CountryISO = countyISO;
        }
    }
}
