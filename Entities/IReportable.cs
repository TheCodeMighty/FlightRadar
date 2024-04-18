namespace FlightRadar
{
    public interface IReportable
    {
        string Accept(INewsProviderVisitor visitor);
    }
}
