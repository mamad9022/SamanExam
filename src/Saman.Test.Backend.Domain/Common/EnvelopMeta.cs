using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Common
{
    public class EnvelopMeta
    {
        public string Location { get; set; }

        public string NextUrl { get; set; }

        public string Message { get; set; }

        public object Descriptor { get; set; }
    }
}
