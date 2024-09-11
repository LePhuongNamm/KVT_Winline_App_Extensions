using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class ChangeETD
    {
        public string Type { set; get; } = string.Empty;
        public string OrderNo { set; get; } = string.Empty;
        public string OldValue { set; get; } = string.Empty;
        public string NewValue { set; get; } = string.Empty;
        public string PositionText { set; get; } = string.Empty;
        public string UserIn { set; get; } = string.Empty;
    }
}
