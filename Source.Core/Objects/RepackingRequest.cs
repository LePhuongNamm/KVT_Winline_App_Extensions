using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class RepackingRequest
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int RepackingCount { get; set; }
        public int QtySum { get; set; }
    }
}
