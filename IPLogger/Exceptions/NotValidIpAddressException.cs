namespace IPLogger.Exceptions;

public class NotValidIpAddressException : Exception
{
    public string IpAddress { get; }

    public NotValidIpAddressException(string ipAddress)
    {
        IpAddress = ipAddress;
    }

    public override string Message => $"Не валидный ip адрес: {IpAddress}";
} 