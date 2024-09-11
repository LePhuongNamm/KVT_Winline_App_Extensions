using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class V_PACKING
    {
        public int No { get; set; }
        public string? PackingNo { get; set; }
        public string? OrderNumber { get; set; }
        public string? TitelCustomer { get; set; }
        public string? Customer { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? ColorCode { get; set; }
        public string? ColorName { get; set; }
        public string? SizeCode { get; set; }
        public string? SizeName { get; set; }
        public double? QtyOrder { get; set; }
        public string? StyleNo { get; set; }
        public string? Gender { get; set; }
        public string? ItemFullCode { get; set; }
        public string? PositionText { get; set; }
        public string? T1 { get; set; }
        public string? OverallTestResult { get; set; }
        public string? BoxType { get; set; }
        public string? Weight { get; set; }
        public string? ToolingNo { get; set; }
        public string? DeliveryDate { get; set; }
        public string? Ordered { get; set; }

        public string? BX1 { get; set; }
        public string? BX2 { get; set; }
        public string? BX3 { get; set; }
        public string? BX4 { get; set; }
        public string? BX5 { get; set; }
        public string? BX6 { get; set; }
        public string? PPbag { get; set; }
        public string? PB { get; set; }
        [NotMapped]
        public string? OrderType { get; set; }
    }
}
