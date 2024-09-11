using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ProdOrderDivide
    {
        public string? ProdOrderNo { set; get; }
        public Int16? Seq { set; get; }
        public Int16? SubSeq { set; get; }
        public Int16? BoxCount { set; get; }
        public Int16? BoxDV { set; get; }
        public string? CurrentBarcode { set; get; }
        public double? QtyOrder { set; get; }
    }
}
