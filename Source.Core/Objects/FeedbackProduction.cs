using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class FeedbackProduction
    {
        public int ID { set; get; }
        public string? ContentFB { set; get; }
        public DateTime? StartDate { set; get; }
        public string? ShiftID { set; get; }
        public DateTime? ShiftDate { set; get; }
        public string? MachineNo { set; get; }
        public string? MID { set; get; }
        public string? ItemFullCode { set; get; }
        public string? Barcode { set; get; }
        public double? QtyOrder { set; get; }
        public string? CreateUser { set; get; }
        public int? IsDone { set; get; }
        public string? ItemDesc { set; get; }
    }
}
