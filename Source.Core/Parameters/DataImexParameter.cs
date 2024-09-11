using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Parameters
{
    public class DataImexParameter
    {
        public string? Dept { get; set; }
        public string? EmpCode { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? Description { get; set; }
        public string? Item { get; set; }
        public string? Size { set; get; }
        public string? Color { get; set; }
        public string? FullCode { get; set; }
    }
}
