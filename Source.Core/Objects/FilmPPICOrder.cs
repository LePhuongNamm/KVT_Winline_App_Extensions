using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class FilmPPICOrder
    {
        public string PackingNo { get; set; } = string.Empty;
        public string? ItemFullCode { get; set; }
        public int? OrderType { get; set; }
        public string? MainOrder { get; set; }
        public int? OrderQty { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? ColorCode { get; set; }
        public string? ColorName { get; set; }
        public string? SizeCode { get; set; }
        public string? SizeName { get; set; }
        public DateTime? InputT { get; set; }
        public string? InputM { get; set; }

        [NotMapped]
        public int? OrderQtyNew { get; set; }
    }
}
