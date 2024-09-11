using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class OverStationTrackingParameter
    {
        public string? ProdOrderNo { get; set; }
        public string? PackingNo { set; get; }
        public string? Item { get; set; }
        public string? Size { set; get; }
        public string? Color { get; set; }
        public string? Customer { get; set; }
        public string? FullCode { get; set; }
        public string? Type { get; set; }
        public string? InOut { get; set; }
        public string? TakenBy { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? Reason { get; set; }
    }
}
