#region usings

using CommandLine;
using IPLogger.Builder;
using IPLogger.DTO;
using IPLogger.Entity;
using IPLogger.Filters;
using IPLogger.Utilities.Helpers;
using IPLogger.Utilities.Parsers;

#endregion

namespace IPLogger;

internal class Program
{
    public static IIpLogsFiltersBuilder? IpLogsFiltersBuilder { get; set; }
    public static IpLogsOptions IpLogsOptions = null!;

    private static async Task Main(string[] args)
    {
        try
        {
            var ipFilterOptionsDto = GetIpFilterParams(args);
            IpLogsOptions = IpReaderOptionsDtoParser.Parse(ipFilterOptionsDto);

            IpLogsFiltersBuilder = new IpLogsFiltersBuilder(IpLogsOptions);

            var logs = await SelectLogs(IpLogsOptions.FileLogPath, IpLogsFiltersBuilder.Build());
            await WriteLogs(IpLogsOptions.FileOutputPath, logs);

            await WriteResult(logs);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static IpFilterOptionsDto GetIpFilterParams(string[] args)
    {
        return
            Parser.Default.ParseArguments<IpFilterOptionsDto>(args)
            .WithNotParsed(
                _ => throw new Exception("Ошибка парсинга параметров фильтрации.")
            ).Value;
    }

    public static async Task<IEnumerable<IpLog>> SelectLogs(string fileLogPath, IEnumerable<IIpLogsFilter>? filters)
    {
        Argument.IsNotNullOrEmpty(fileLogPath, nameof(fileLogPath));

        return
            await new IpLogsReader(new IpLogParser())
            .Read(fileLogPath, filters);
    }

    public static async Task WriteLogs(string fileOutput, IEnumerable<IpLog> ipLogs)
    {
        Argument.IsNotNullOrEmpty(fileOutput, nameof(fileOutput));

        if (!File.Exists(fileOutput))
        {
            File.Create(fileOutput);
        }


        await using var stream = new StreamWriter(fileOutput, false);

        foreach (var log in ipLogs)
        {
            await stream.WriteLineAsync(
                log.ToString()
            );
        }
    }

    public static async Task WriteResult(IEnumerable<IpLog> logs)
    {
        await Console.Out.WriteLineAsync(IpLogsOptions.ToString());

        foreach (var log in logs)
        {
            await Console.Out.WriteLineAsync(log.ToString());
        }
    }
}