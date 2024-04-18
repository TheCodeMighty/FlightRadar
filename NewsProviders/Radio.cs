namespace FlightRadar
{
    public class Radio : INewsProviderVisitor
    {
        public string Name { get; set; }
        public string Visit(Airport airport)
        {
            return $"Reporting for {Name}, Ladies and Gentelmen, we are at the {airport.Name}";
        }

        public string Visit(CargoPlane cargoPlane)
        {
            return $"Reporting for {Name}, Ladies and Gentelmen, we are seeing the {cargoPlane.Serial} aircraft fly above us";
        }

        public string Visit(PassengerPlane passengerPlane)
        {
            return $"Reporting for {Name}, Ladies and Gentelmen, we've just witnessed {passengerPlane.Serial} take off";
        }
    }
}
