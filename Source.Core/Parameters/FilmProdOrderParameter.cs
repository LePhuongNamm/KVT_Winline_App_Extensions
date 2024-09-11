using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class FilmProdOrderParameter
    {
        public string? ProdOrderNo { get; set; }
        public string? PackingNo { set; get; }
        public string? Barcode { get; set; }
        public string? ScanStatus { get; set; }
    }
}
