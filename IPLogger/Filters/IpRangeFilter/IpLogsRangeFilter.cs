#region usings

using System.Net;
using IPLogger.Entity;
using IPLogger.Exceptions;
using IPLogger.Utilities.Helpers;

#endregion

namespace IPLogger.Filters.IpRangeFilter;

public class IpLogsRangeFilter : IIpLogsFilter
{
    public byte[] StartIp { get; protected set; }
    public int? Mask { get; protected set; }

    private const int V4MinMaskSize = 0;
    private const int V4MaxMaskSize = 32;

    public IpLogsRangeFilter(IPAddress startIp)
    {
        Argument.IsNotNull(startIp, nameof(startIp));

        StartIp = startIp.GetAddressBytes();
    }

    public IpLogsRangeFilter(IPAddress startIp, int mask)
        : this(startIp)
    {
        if (mask is < V4MinMaskSize or > V4MaxMaskSize)
        {
            throw new NotValidAddressMaskException(V4MinMaskSize, V4MaxMaskSize);
        }

        Mask = mask;
    }

    public bool IsSuitable(IpLog ipLog)
    {
        Argument.IsNotNull(ipLog, nameof(ipLog));

        return IsIpInRange(ipLog.Address, Mask ?? V4MaxMaskSize);
    }

    protected bool IsIpInRange(IPAddress targetIp, int subnetMaskBits = V4MaxMaskSize)
    {
        var targetIpBytes = targetIp.GetAddressBytes();

        if (subnetMaskBits is < V4MinMaskSize or > V4MaxMaskSize)
        {
            throw new NotValidAddressMaskException(V4MinMaskSize, V4MaxMaskSize);
        }

        var fullBytes = subnetMaskBits / 8;
        var remainingBits = subnetMaskBits % 8;

        for (var i = 0; i < fullBytes; i++)
        {
            if (StartIp[i] != targetIpBytes[i])
            {
                return false;
            }
        }

        if (remainingBits <= 0)
        {
            return true;
        }

        var mask = (byte)(255 << 8 - remainingBits);

        return (StartIp[fullBytes] & mask) == (targetIpBytes[fullBytes] & mask);
    }
}