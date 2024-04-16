#region usings

using IPLogger.Entity;

#endregion

namespace IPLogger.Filters.IpDateFilter;

public class IpLogsDateFilter : IIpLogsFilter
{
    public DateTime DateStart { get; }
    public DateTime DateEnd { get; }

    public IpLogsDateFilter(DateTime dateStart)
    {
        DateStart = dateStart;
    }

    public IpLogsDateFilter(DateTime dateStart, DateTime dateEnd) : this(dateStart)
    {
        DateEnd = dateEnd;
    }

    public bool IsSuitable(IpLog ipLog)
    {
        return ipLog.TimeVisit > DateStart && ipLog.TimeVisit < DateEnd;
    }
}