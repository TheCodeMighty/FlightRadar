namespace FlightRadar
{
    public interface INewsProviderVisitor
    {
        string Visit(Airport airport);
        string Visit(CargoPlane cartgoPlane);
        string Visit(PassengerPlane passengerPlane);
    }
}
