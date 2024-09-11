using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ProductionOrderArticle
    {
        public int IsYear { get; set; }
        public int IsMonth { get; set; }
        public int Article { get; set; }
        public int Prod { get; set; }
        public int TargetQty { get; set; }
        public int YieldQty { get; set; }
    }
}
