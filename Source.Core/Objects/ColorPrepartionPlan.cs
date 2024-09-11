using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ColorPrepartionPlan
    {
        public DateTime? InputDate { get; set; }
        public string? Customer { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? MCStatus { get; set; }
        public string? ColorCode { get; set; }
        public string? ColorName { get; set; }
        public string? StartDate { get; set; }
        public double? QtyOrder { get; set; }
        public DateTime? ShipETD { get; set; }
        public double? QtyScanner { get; set; }
        public string? Article { get; set; }
        public string? MachineNo { get; set; }
    }
}
