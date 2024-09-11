using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class QCSSBCWhsParameter
    {
        public string? Type { get; set; }
        public string? SubName { get; set; }
        public string? Item { get; set; }
        public string? Size { set; get; }
        public string? Color { get; set; }
        public string? QRCode { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
