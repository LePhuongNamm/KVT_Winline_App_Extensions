using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class OrderCheckingParameter
    {
        public string? IsCompany { set; get; }
        public string? DateDeliveryFrom { set; get; }
        public string? DateDeliveryTo { set; get; }
        public string? VoucherType { set; get; }
    }
}
