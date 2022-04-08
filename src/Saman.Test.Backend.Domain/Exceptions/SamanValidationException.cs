using Saman.Test.Backend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Exceptions
{
    public class SamanValidationException : SamanException
    {
        public SamanValidationException() : base()
        {
            ErrorCode = ErrorCode.BadRequest;
        }

        public SamanValidationException(Dictionary<string, string> validationErrors) : this()
        {
            ValidationErrors = validationErrors;
        }

        public Dictionary<string, string> ValidationErrors { get; private set; }
    }
}
