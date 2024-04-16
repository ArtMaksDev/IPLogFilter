namespace IPLogger.Exceptions;

public class NotValidAddressMaskException : Exception
{
    private readonly int _minRange;
    private readonly int _maxRange;

    public NotValidAddressMaskException(int minRange, int maxRange)
    {
        _minRange = minRange;
        _maxRange = maxRange;
    }
    public override string Message => $"Маска подесети может быть от {_minRange} до {_maxRange}.";
}