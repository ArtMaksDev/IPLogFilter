#region usings

using IPLogger.Entity;

#endregion

namespace IPLogger.Utilities.Parsers;

public interface IIpLogParser
{
    public IpLog Parse(string log);
}