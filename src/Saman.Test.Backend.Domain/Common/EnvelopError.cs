using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Common
{
    public class EnvelopError
    {
        public ErrorCode ErrorCode { get; set; }

        public string CustomMessage { get; set; }

        public Exception Exception { get; set; }
    }
}
