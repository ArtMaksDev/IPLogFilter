#region usings

using System.Net;
using IPLogger.DTO;
using IPLogger.Utilities.Helpers;

#endregion

namespace IPLogger;

public class IpLogsOptions
{
    public IpLogsOptions(string fileLogPath, string fileOutputPath)
    {
        FileLogPath = fileLogPath;
        FileOutputPath = fileOutputPath;
    }


    public string FileLogPath { get; set; }

    public string FileOutputPath { get; set; }

    public IPAddress? AddressStart { get; set; }

    public int? AddressMask { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeEnd { get; set; }

    public override string ToString()
    {
        var optionNameInfo = new OptionNameInfo(typeof(IpFilterOptionsDto));

        return
            $@"
            {optionNameInfo.GetName(nameof(FileLogPath))}: {FileLogPath}
            {optionNameInfo.GetName(nameof(FileOutputPath))}: {FileOutputPath}
            {optionNameInfo.GetName(nameof(AddressStart))}: {AddressStart}
            {optionNameInfo.GetName(nameof(AddressMask))}: {AddressMask}
            {optionNameInfo.GetName(nameof(TimeStart))}: {TimeStart:d}
            {optionNameInfo.GetName(nameof(TimeEnd))}: {TimeEnd:d}";
    }
}