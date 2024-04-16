namespace IPLogger.Filters.IpDateFilter;

public class IpLogsDateFilterCreator : IIpLogsFilterCreator
{
    private readonly DateTime? _dateStart;
    private readonly DateTime? _dateEnd;

    public IpLogsDateFilterCreator(DateTime? dateStart, DateTime? dateEnd)
    {
        _dateStart = dateStart;
        _dateEnd = dateEnd;
    }
    public IIpLogsFilter? Create()
    {
        if (_dateStart == null)
        {
            return null;
        }

        return _dateEnd == null 
            ? new IpLogsDateFilter(_dateStart.Value)
            : new IpLogsDateFilter(_dateStart.Value, _dateEnd.Value);
    }
}