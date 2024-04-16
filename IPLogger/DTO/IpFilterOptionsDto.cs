#region usings

using CommandLine;
using IPLogger.Utilities.Helpers;

#endregion

namespace IPLogger.DTO;

public class IpFilterOptionsDto
{
    [Option("file-log", Required = true, HelpText = "Путь к файлу с логами.")]
    public string FileLogPath { get; set; } = null!;

    [Option("file-output", Required = true, HelpText = "Путь к файлу с результатом.")]
    public string FileOutputPath { get; set; } = null!;

    [Option("address-start", HelpText = "Нижняя граница диапазона адресов.")]
    public string? AddressStart { get; set; }

    [Option("address-mask", HelpText = "Маска подсети, задающая верхнюю границу диапазона десятичное число.")]
    public string? AddressMask { get; set; }

    [Option("time-start", Required = true, HelpText = "Нижняя граница временного интервала.")]
    public string TimeStart { get; set; } = null!;

    [Option("time-end", Required = true, HelpText = "Верхняя граница временного интервала.")]
    public string TimeEnd { get; set; } = null!;

    public override string ToString()
    {
        var optionNameInfo = new OptionNameInfo(typeof(IpFilterOptionsDto));

        return
            $@"
            {optionNameInfo.GetName(nameof(FileLogPath))}: {FileLogPath}
            {optionNameInfo.GetName(nameof(FileOutputPath))}: {FileOutputPath}
            {optionNameInfo.GetName(nameof(AddressStart))}: {AddressStart}
            {optionNameInfo.GetName(nameof(AddressMask))}: {AddressMask}
            {optionNameInfo.GetName(nameof(TimeStart))}: {TimeStart}
            {optionNameInfo.GetName(nameof(TimeEnd))}: {TimeEnd}";
    }
}