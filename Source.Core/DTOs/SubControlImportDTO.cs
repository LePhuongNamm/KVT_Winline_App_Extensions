using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.DTOs
{
    public class SubControlImportDTO
    {
        public string DateTransfer { get; set; } = "";
        public string SubTransfer { get; set; } = "";
        public List<string> Barcodes { get; set; } = new List<string>();
    }
}
