using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class ProdPendingParameter
    {
        public string? FormDate { get; set; }
        public string? ToDate { get; set; }
        public string? ProdOrderNo { get; set; }
        public string? Item { get; set; }
        public string? Size { set; get; }
        public string? Color { get; set; }
        public string? Status { get; set; }
    }
}
