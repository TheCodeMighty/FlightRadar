namespace OOD_Project1
{
    public interface IReportable
    {
        string Accept(INewsProviderVisitor visitor);
    }
}
