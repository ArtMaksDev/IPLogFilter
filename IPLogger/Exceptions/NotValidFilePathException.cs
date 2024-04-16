using IPLogger.Utilities.Helpers;

namespace IPLogger.Exceptions;

public class NotValidFilePathException : Exception
{
    public readonly string Path;

    public NotValidFilePathException(string path, string? message = null)
        : base(message)
    {
        Argument.IsNotNullOrEmpty(path, nameof(path));

        Path = path;
    }

    public override string Message =>
        base.Message + $"\nУказан невалидный путь до файла: {Path}";
}