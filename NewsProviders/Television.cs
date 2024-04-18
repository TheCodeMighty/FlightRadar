namespace FlightRadar
{
    public class Television : INewsProviderVisitor
    {
        public string Name { get; set; }

        public string Visit(Airport airport)
        {
            return $"An image of {airport.Name}";
        }

        public string Visit(CargoPlane cargoPlane)
        {
            return $"An image of {cargoPlane.Serial} cargo plane";
        }

        public string Visit(PassengerPlane passengerPlane)
        {
            return $"An image of {passengerPlane.Serial} passenger plane";
        }
    }
}
