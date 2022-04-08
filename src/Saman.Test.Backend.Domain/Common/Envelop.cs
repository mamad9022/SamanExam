using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Common
{
    public class Envelop
    {
        public object Data { get; set; }
        public EnvelopMeta Meta { get; set; }
        public EnvelopError Error { get; set; }
        public Dictionary<string, string> ValidationErrors { get; set; }

    }
}
