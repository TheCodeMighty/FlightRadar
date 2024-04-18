namespace FlightRadar
{
    public class PassengerPlane : BaseEntity, IReportable
    {
        public string Serial { get; set; }
        public string CountryISO { get; set; }
        public string Model { get; set; }
        public ushort FirstClassSize { get; set; }
        public ushort BusinessClassSize { get; set; }
        public ushort EconomyClassSize { get; set; }

        public string Accept(INewsProviderVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public PassengerPlane(string identifier, ulong id, string serial, string countryISO, string model, ushort firstClassSize, ushort businessClassSize, ushort economyClassSize) : base(identifier, id)
        {
            Serial = serial;
            CountryISO = countryISO;
            Model = model;
            FirstClassSize = firstClassSize;
            BusinessClassSize = businessClassSize;
            EconomyClassSize = economyClassSize;
        }
    }
}
