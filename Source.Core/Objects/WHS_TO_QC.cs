using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class WHS_TO_QC
    {
        public Nullable<System.DateTime> ScaleDate { get; set; }
        public string? fBarcode { get; set; }
        public string? PONUMBER { get; set; }
        public string? STYLE_NO { get; set; }
        public string? Cust { get; set; }
        public string? Item { get; set; }
        public string? Color { get; set; }
        public string? SIZE { get; set; }
        public string? Box { get; set; }
        //public int OtherWeight { get; set; }
        public Nullable<int> StdPairs { get; set; }
        public Nullable<short> ReQCPairs { get; set; }
        public Nullable<int> ReQCWeight { get; set; }
        public Nullable<System.DateTime> ReQCDate { get; set; }
        public Nullable<System.TimeSpan> ReQCTime { get; set; }
        public Nullable<short> ReWHPairs { get; set; }
        public Nullable<int> ReWHWeight { get; set; }
        public Nullable<System.DateTime> ReWHDate { get; set; }
        public Nullable<System.TimeSpan> ReWHTime { get; set; }

        //
        public short BoxWeight { get; set; }
        public decimal Pe_W { get; set; }
        public decimal Fo_W { get; set; }
        public decimal Cp_W { get; set; }

        public decimal NetWeight { get; set; }
        public Nullable<short> RealPairs { get; set; }

        public Nullable<int> Compare { get; set; }
        public Nullable<int> RealWeight { get; set; }
        public Nullable<decimal> StdGrossWeight { get; set; }

        public string? OptionInput { get; set; }
        public Nullable<System.DateTime> NgayScan { get; set; }
        public Nullable<System.TimeSpan> GioScan { get; set; }


        public Nullable<decimal> iniRealWgt { get; set; }
        public Nullable<decimal> iniDiffWeight { get; set; }
        public int iniDiffPair { get; set; }

        public string? BXType { get; set; }

        public double BXQty { get; set; }

        public string? PBCode { get; set; }
        public string? ColorLevel { get; set; }
    }
}
