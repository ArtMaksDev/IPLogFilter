using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Exceptions
{
    public class DateFormatException : Exception
    {
        public override string Message => "Неверный формат даты. Даты указываются в формате:  dd.MM.yyyy";
    }
}
