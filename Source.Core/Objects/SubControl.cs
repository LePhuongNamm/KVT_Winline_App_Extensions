using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class SubControl
    {
        public string? SubName { get; set; }
        public string? fBarcode { get; set; }
        public string? PackingNo { get; set; }
        public string? FGScan { get; set; }
        public string? PPScan { get; set; }
        public string? Status { get; set; }
        public DateTime? DateTransfer { get; set; }
        public double? QtyOrder { get; set; }
        public string? EmpScan { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? UpdateBy { get; set; }
        public string? TitelCustomer { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? ColorCode { get; set; }
        public string? ColorName { get; set; }
        public string? SizeCode { get; set; }
        public string? SizeName { get; set; }
        public string? OrderNumber { get; set; }
        public string? StyleNo { get; set; }
        public string? ItemFullCode { get; set; }
    }
}
