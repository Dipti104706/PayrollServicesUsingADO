using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollServicesUsingADO
{
    public class CustomException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            NO_ROW_AFFECTED,
            SP_NOT_FOUND
        }

        public CustomException(ExceptionType type, string massage) : base(massage)
        {
            this.type = type;
        }
    }
}
