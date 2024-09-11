using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class PackingInfo
    {
        public string ItemFullCode { get; set; } = string.Empty;
        public string? ItemCode { get; set; }
        public string? ItemName { get; set;}
        public string? SizeCode { get; set; }
        public string? SizeName { get; set; }
        public int? QtyPerBag { get; set; }
        public int? QtyPerBox { get; set; }
        public int? TotalRow { get; set; }
    }
}
