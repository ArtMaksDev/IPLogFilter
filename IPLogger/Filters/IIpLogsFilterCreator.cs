namespace IPLogger.Filters;

public interface IIpLogsFilterCreator
{
    public IIpLogsFilter? Create();
}