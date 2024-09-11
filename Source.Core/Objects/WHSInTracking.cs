using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class WHSInTracking
    {
        public string? PackingNo { get; set; }
        public string? fBarcode { get; set; }
        public string? PONUMBER { get; set; }
        public string? STYLE_NO { get; set; }
        public string? CUSTOMER { get; set; }
        public string? ITEMNAME { get; set; }
        public string? ITEMCOLOR { get; set; }
        public string? SIZE { get; set; }
        public int? BOXQTY1 { get; set; }
        public int? Pairs { get; set; }
        public string? Boxco { get; set; }
        public int? RealWeightGram { get; set; }
        public string? ItemFullCode { get; set; }
        public string? Scan_in { get; set; }
        public string? Status { get; set; }
        public string? OptionInput { get; set; }
        public DateTime? ScaleDate { get; set; }
        public DateTime? WhsToQc { get; set; }
        public DateTime? QcToWhs { get; set; }
        public string? BarcodeImport { get; set; }
    }
}
