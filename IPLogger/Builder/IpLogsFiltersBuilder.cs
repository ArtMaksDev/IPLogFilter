#region usings

using IPLogger.Filters;
using IPLogger.Filters.IpDateFilter;
using IPLogger.Filters.IpRangeFilter;

#endregion

namespace IPLogger.Builder;

public class IpLogsFiltersBuilder : IIpLogsFiltersBuilder
{
    private readonly IpLogsOptions? _ipLogOptions;

    public IpLogsFiltersBuilder(IpLogsOptions? ipLogOptions)
    {
        _ipLogOptions = ipLogOptions;
    }

    public IEnumerable<IIpLogsFilter>? Build()
    {
        var filters = new List<IIpLogsFilter>();
        var dateFilter = new IpLogsDateFilterCreator(_ipLogOptions.TimeStart, _ipLogOptions.TimeEnd).Create();
        var rangeFilter = new IpLogsRangeFilterCreator(_ipLogOptions.AddressStart, _ipLogOptions.AddressMask).Create();

        if (dateFilter != null)
        {
            filters.Add(dateFilter);
        }

        if (rangeFilter != null)
        {
            filters.Add(rangeFilter);
        }

        return filters.Any()
            ? filters
            : null;
    }
}