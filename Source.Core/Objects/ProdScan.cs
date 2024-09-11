using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ProdScan
    {
        public string? ShiftDate { set; get; }
        public string? ShiftID { set; get; }
        public string? MachineNo { set; get; }
        public string? ItemName { set; get; }
        public string? ColorName { set; get; }
        public string? SizeName { set; get; }
        public string? OrderNumber { set; get; }
        public string? MesOrderNumber { set; get; }
        public string? ArticleNo { set; get; }
        public string? Barcode { set; get; }
        public int? QtyOrder { set; get; }
        public string? PackingNo { set; get; }
        public DateTime? DateScan { set; get; }
        public string? ColorLevel { set; get; }
        public string? CreateUser { set; get; }
        public int? QtyTotal { set; get; }
        public int? QtyReal { set; get; }
        public int? QtyDefect { set; get; }
        public int? QtyScanned { set; get; }
        public int? QtyInShift { set; get; }
    }
}
