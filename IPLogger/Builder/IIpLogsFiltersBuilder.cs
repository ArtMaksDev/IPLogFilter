#region usings

using IPLogger.Filters;

#endregion

namespace IPLogger.Builder;

public interface IIpLogsFiltersBuilder
{
    public IEnumerable<IIpLogsFilter>? Build();
}