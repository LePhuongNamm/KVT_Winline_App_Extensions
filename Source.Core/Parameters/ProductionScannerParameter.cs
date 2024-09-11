using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class ProductionScannerParameter
    {
        public string? MachineNo { get; set; }
        public string? Item { get; set; }
        public string? Shift { get; set; }
        public string? Barcode { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
