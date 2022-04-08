using Saman.Test.Backend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Exceptions
{
    public class SamanException : Exception
    {
        public SamanException()
        {
        }
        public SamanException(ErrorCode errorCode, string customMessage = null, object value = null, Exception innerException = null) : base(customMessage, innerException)
        {
            ErrorCode = errorCode;
            CustomMessage = customMessage;
            Value = value;
        }

        public ErrorCode ErrorCode { get; set; }

        public string CustomMessage { get; set; }

        public object Value { get; set; }

        public int HttpStatusCode => int.Parse(ErrorCode.ToString("D").Substring(0, 3));
    }
}
