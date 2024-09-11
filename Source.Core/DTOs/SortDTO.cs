using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.DTOs
{
    public class SortDTO
    {
        public int Stt { get; set; }
        public string SortColumn { get; set; } = "";
        public string SortValue { get; set; } = "";
    }
}
