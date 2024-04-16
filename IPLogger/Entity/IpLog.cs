#region usings

using System.Net;

#endregion

namespace IPLogger.Entity;

public class IpLog
{
    public IpLog(IPAddress address, DateTime timeVisit)
    {
        Address = address;
        TimeVisit = timeVisit;
    }

    public IPAddress Address { get; }
    public DateTime TimeVisit { get; }

    public override string ToString()
    {
        return $"{Address}:{TimeVisit}";
    }
}