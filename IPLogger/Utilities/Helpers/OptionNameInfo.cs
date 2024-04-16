#region usings

using System.Reflection;
using CommandLine;

#endregion

namespace IPLogger.Utilities.Helpers;

public class OptionNameInfo
{
    public OptionNameInfo(Type type)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }

    public Type Type { get; }
    public string GetName(string propertyName)
    {
        return 
            Type
            .GetProperty(propertyName)!
            .GetCustomAttribute<OptionAttribute>()!.LongName;
    }
}