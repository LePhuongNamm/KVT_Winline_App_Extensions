using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class CIDTBL
    {
        public string ID { set; get; } = string.Empty;
        public string PASSWORD { set; get; } = string.Empty;
        public string? SEC_LEVEL { set; get; }
        public string? Name { set; get; }
        public string Department { set; get; } = string.Empty;
        public string? BRAND { set; get; }
        public string? CUSTOMER { set; get; }
    }
}
