using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class TblETDChangeHistory
    {
        public string? CodeImport { set; get; }
        public string? OrderNo { set; get; }
        public decimal? Price { set; get; }
        public DateTime? ETD { set; get; }
        public string? PositionText { set; get; }
    }
}
