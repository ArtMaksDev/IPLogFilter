#region usings

using IPLogger.Entity;
using IPLogger.Filters;
using IPLogger.Utilities.Parsers;

#endregion

namespace IPLogger;

public class IpLogsReader
{
    private readonly IpLogParser _ipLogParser;
    public IpLogsReader(IpLogParser ipLogParser)
    {
        _ipLogParser = ipLogParser;
    }

    public async Task<IEnumerable<IpLog>> Read(string fileLogPath, IEnumerable<IIpLogsFilter>? logsFilters = null)
    {
        using var stream = new StreamReader(fileLogPath);
        var selectLogs = new List<IpLog>();
        var log = string.Empty;

        while ((log = await stream.ReadLineAsync()) != null)
        {
            if (logsFilters == null)
            {
                continue;
            }

            var ipLog = _ipLogParser.Parse(log!);

            if (!logsFilters.All(
                    logsFilter => logsFilter.IsSuitable(ipLog)))
            {
                continue;
            }

            selectLogs.Add(ipLog);
        }

        return selectLogs;
    }
}