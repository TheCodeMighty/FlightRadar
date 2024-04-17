namespace OOD_Project1
{
    public class CargoPlane : BaseEntity, IReportable
    {
        public string Serial { get; set; }
        public string CountryISO { get; set; }
        public string Model { get; set; }
        public float MaxLoad { get; set; }

        public string Accept(INewsProviderVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public CargoPlane(string identifier, ulong id, string serial, string countryISO, string model, float maxLoad) : base(identifier, id)
        {
            Serial = serial;
            CountryISO = countryISO;
            Model = model;
            MaxLoad = maxLoad;
        }
    }
}
