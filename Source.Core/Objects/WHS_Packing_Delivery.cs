using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class WHS_Packing_Delivery
    {
        public string? PackingNo { get; set; }
        public string? OrderNumber { get; set; }
        public string? Ordered { get; set; }
        public string? TitelCustomer { get; set; }
        public string? Customer { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? ItemName { get; set; }
        public string? ColorName { get; set; }
        public double? QtyOrder { get; set; }
        public string? StyleNo { get; set; }
        public string? Gender { get; set; }
        public string? DeliveryNote { get; set; }
        public string? InvoiceNo { get; set; }
    }
}
