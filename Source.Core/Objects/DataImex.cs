using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class DataImex
    {
        public int ID { get; set; }
        public string? QRCode { get; set; }
        public string? Description { get; set;}
        public DateTime? DateInput { get; set;}
        public string? EmpCode { get; set;}
        public string? Dept { get; set;}
        public DateTime? Lastupdate { get; set;}
        public string? UpdateBy { get; set; }
        public string? LastScanDate { get; set;}
        public string? Shift { get; set; }
        public DateTime? ShiftDate { get; set; }
        public string? PackingNo { get; set; }
        public string? ItemName { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public double? QtyOrder { get; set; }
        public string? OrderNumber { get; set; }
        public string? StyleNo { get; set; }
    }
}
