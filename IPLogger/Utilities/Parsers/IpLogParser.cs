#region usings

using System.Net;
using IPLogger.Entity;
using IPLogger.Utilities.Helpers;

#endregion

namespace IPLogger.Utilities.Parsers;

public class IpLogParser : IIpLogParser
{
    public IpLog Parse(string log)
    {
        Argument.IsNotNullOrEmpty(log, nameof(log));

        var logParts = log!.Split(':', 2);

        return new IpLog(
            IPAddress.Parse(logParts[0]),
            DateTime.Parse(logParts[1])
        );
    }
}