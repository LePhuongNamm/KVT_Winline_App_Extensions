using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class SeparetionRecord
    {
        public DateTime? InputDate { get; set; }
        public string? InputUser { get; set; }
        public string? BarcodeInput { get; set; }
        public int? QtyInput { get; set; }
        public string? BarcodeOutput { get; set; }
        public int? QtyOutput { get; set; }
        public string? PackingNo { get; set; }
        public string? TitelCustomer { get; set; }
        public string? ItemName { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public string? OrderNumber { get; set; }
        public string? StyleNo { get; set; }
        public int? Checkbox { get; set; }
        public int? IsRollBack { get; set; }
    }
}
