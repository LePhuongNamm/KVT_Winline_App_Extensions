using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class WHS_Packing_Delivery_Parameter
    {
        public string? TitleCustomer { get; set; }
        public string? Item { get; set; }
        public string? Size { set; get; }
        public string? Color { get; set; }
        public string? DeliveryDate { get; set; }
        public string? DeliveryNote { get; set; }
        public string? DPONo { get; set; }
        public string? StyleNo { get; set; }
    }
}
