#region usings

using System.Globalization;
using System.Net;
using IPLogger.DTO;
using IPLogger.Utilities.Helpers;
using IPLogger.Utilities.Validations;

#endregion

namespace IPLogger.Utilities.Parsers;

public class IpReaderOptionsDtoParser
{
    public static IpLogsOptions Parse(IpFilterOptionsDto filterOptionsDto)
    {
        Argument.IsNotNull(filterOptionsDto, nameof(filterOptionsDto));

        IpFilterValidation.Validate(filterOptionsDto);

        var options = new IpLogsOptions(filterOptionsDto.FileLogPath, filterOptionsDto.FileOutputPath)
        {
            TimeStart = DateTime.ParseExact(
                filterOptionsDto.TimeStart,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None
                ),
            TimeEnd = DateTime.ParseExact(
                filterOptionsDto.TimeEnd,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None
            )
        };

        if (filterOptionsDto.AddressStart != null)
        {
            options.AddressStart = IPAddress.Parse(filterOptionsDto.AddressStart);
        }

        if (filterOptionsDto.AddressMask != null)
        {
            options.AddressMask = int.Parse(filterOptionsDto.AddressMask);
        }



        return options;
    }
}