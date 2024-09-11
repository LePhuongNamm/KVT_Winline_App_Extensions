using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class Component
    {
        public int? Id { get; set; }
        public string? TrackNo { set; get; }
        public string? Barcode { set; get; }
        public int? Seq { set; get; }
        public string? CompType { set; get; }
        public string? MachineNo { set; get; }
        public DateTime? CreateDate { set; get; }
        public DateTime? OutDate { set; get; }
        public string? CreateBy { set; get; }
        public string? ItemName { set; get; }
        public string? ColorName { set; get; }
        public string? SizeName { set; get; }
        public string? ItemCode { set; get; }
        public string? ColorCode { set; get; }
        public string? SizeCode { set; get; }
        public int? Qty { set; get; }
        public int? QtyOut { set; get; }

        public string? Remark { set; get; }
        [NotMapped]
        public bool IsSelected { get; set; } = false;
    }
}
