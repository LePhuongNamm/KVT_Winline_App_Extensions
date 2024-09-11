using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class FeedbackSSBC
    {
        public DateTime? FBDate { set; get; }
        public string? Shift { set; get; }
        public string? fBarcode { set; get; }
        public string? Reason { set; get; }
        public int? Checked { set; get; }
        public string? MC { set; get; }
        public double? QtyOrder { set; get; }
        public string? ItemName { set; get; }
    }
}
