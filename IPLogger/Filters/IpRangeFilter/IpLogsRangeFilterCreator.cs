#region usings

using System.Net;

#endregion

namespace IPLogger.Filters.IpRangeFilter;

public class IpLogsRangeFilterCreator : IIpLogsFilterCreator
{
    private readonly IPAddress? _startIp;
    private readonly int? _mask;


    public IpLogsRangeFilterCreator(IPAddress? startIp, int? mask)
    {
        _startIp = startIp;
        _mask = mask;
    }
    public IIpLogsFilter? Create()
    {
        if (_startIp == null)
        {
            return null;
        }

        return _mask == null
            ? new IpLogsRangeFilter(_startIp)
            : new IpLogsRangeFilter(_startIp, _mask.Value);
    }
}