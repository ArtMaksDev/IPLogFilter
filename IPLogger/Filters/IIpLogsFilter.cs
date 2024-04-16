#region usings

using IPLogger.Entity;

#endregion

namespace IPLogger.Filters;

public interface IIpLogsFilter
{
    public bool IsSuitable(IpLog ipLog);
}