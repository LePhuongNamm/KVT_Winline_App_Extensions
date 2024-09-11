using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ProdPending
    {
        public string? Barcode { get; set; }
        public string? Reason { get; set; }
        public DateTime? ScanDate { get; set; }
        public string? ScanDay { get; set; }
        public string? ScanTime { get; set; }
        public string? ArticleNo { get; set; }
        public string? ScannedSource { get; set; }
        public string? OrderNumber { get; set; }
        public string? StyleNo { get; set; }
        public string? ItemName { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public double QtyOrder { get; set; }
        public string? OneDay { get; set; }
    }
}
