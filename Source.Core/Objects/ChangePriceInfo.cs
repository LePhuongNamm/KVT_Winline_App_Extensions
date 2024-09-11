using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ChangePriceInfo
    {
        public string? mesokey {  get; set; }
        public string? ProductNumber { get; set; }
        public string? PriceList { get; set; }
        public string? CustomerNumber { get; set; }
        public string? PriceUnit { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
        public string? mesoyear { get; set; }
    }
}
