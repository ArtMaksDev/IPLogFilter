#region usings

using System.Globalization;
using System.Net;
using IPLogger.DTO;
using IPLogger.Exceptions;
using IPLogger.Utilities.Helpers;

#endregion

namespace IPLogger.Utilities.Validations;

public static class IpFilterValidation
{
    private const int MinMaskValue = 0;
    private const int MaxMaskValue = 32;

    public static void Validate(IpFilterOptionsDto ipFilterOptions)
    {
        var optionNameInfo = new OptionNameInfo(typeof(IpFilterOptionsDto));

        if (!Path.IsPathFullyQualified(ipFilterOptions.FileLogPath))
        {
            throw new NotValidFilePathException(
                ipFilterOptions.FileLogPath,
                $"{optionNameInfo.GetName(nameof(ipFilterOptions.FileLogPath))}:");
        }

        if (!Path.IsPathFullyQualified(ipFilterOptions.FileOutputPath))
        {
            throw new NotValidFilePathException(
                ipFilterOptions.FileOutputPath,
                $"{optionNameInfo.GetName(nameof(ipFilterOptions.FileOutputPath))}:");
        }

        if (!string.IsNullOrEmpty(ipFilterOptions.AddressMask))
        {
            if (string.IsNullOrEmpty(ipFilterOptions.AddressStart))
            {
                throw new ArgumentException(
                    $"Нельзя указывать параметр {optionNameInfo.GetName(nameof(ipFilterOptions.AddressMask))} " +
                    $"без {optionNameInfo.GetName(nameof(ipFilterOptions.AddressStart))}."
                );
            }

            if (!int.TryParse(ipFilterOptions.AddressMask, out var result) || (result < MinMaskValue || result > MaxMaskValue))
            {
                throw new NotValidAddressMaskException(MinMaskValue, MaxMaskValue);
            }

        }

        if (ipFilterOptions.AddressStart != null)
        {
            if (!IPAddress.TryParse(ipFilterOptions.AddressStart, out _))
            {
                throw new NotValidIpAddressException(ipFilterOptions.AddressStart! +
                    $" для {optionNameInfo.GetName(nameof(ipFilterOptions.AddressStart))}");
            }
        }

        if (!DateTime.TryParseExact(
                ipFilterOptions.TimeStart,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, 
                out _
            ))
        {
            throw new DateFormatException();
        }
        
        if (!DateTime.TryParseExact(
                ipFilterOptions.TimeEnd,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _
            ))
        {
            throw new DateFormatException();
        }
    }
}