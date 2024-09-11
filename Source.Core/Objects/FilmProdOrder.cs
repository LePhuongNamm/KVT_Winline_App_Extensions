using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class FilmProdOrder
    {
        public string ProdOrderNo { get; set; } = string.Empty;
        public int Seq { get; set; }
        public int SubSeq { get; set; }
        public int BoxCount { get; set; }
        public int BoxDivide { get; set; }
        public string? Barcode { get; set; }
        public string? PackingNo { get; set; }
        public string? ItemFullCode { get; set; }
        public int? OrderQty { get; set; }
        public string? ScanStatus { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? ColorCode { get; set; }
        public string? ColorName { get; set; }
        public string? SizeCode { get; set; }
        public string? SizeName { get; set; }
        public int? OrderType { get; set; }
        public DateTime? InputT { get; set; }
        public string? InputM { get; set; }
        public string? BoxType { get; set;}
        public string? Bags { get; set; }

        [NotMapped]
        public int? OrderQtyNew { get; set; }
    }
}
