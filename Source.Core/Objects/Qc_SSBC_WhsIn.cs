using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class Qc_SSBC_WhsIn
    {
        public DateTime? ScaleDate { get; set; }
        public DateTime? ScaleDateFirst { get; set; }
        public TimeSpan? ScaleTimeFirst { get; set; }
        public string? fBarcode { get; set; }
        public string? PackingNo { get; set; }
        public string? PONUMBER { get; set; }
        public string? STYLE_NO { get; set; }
        public string? Cust { get; set; }
        public string? Item { get; set; }
        public string? Color { get; set; }
        public string? SIZE { get; set; }
        public string? Box { get; set; }
        public decimal? Pe_W { get; set; }
        public decimal? Fo_W { get; set; }
        public decimal? Cp_W { get; set; }
        public decimal? NetWeight { get; set; }
        public int? StdPairs { get; set; }
        public int? RealPairs { get; set; }
        public int? Compare { get; set; }
        public int? RealWeight { get; set; }
        public decimal? StdGrossWeight { get; set; }
        public string? OptionInput { get; set; }
        public decimal? RealWeightProductOnly { get; set; }
        public decimal? NetStdWeightProductOnly { get; set; }
        public decimal? C105PercentOfNetStdWeight { get; set; }
        public decimal? C95PercentOfNetStdWeight { get; set; }
        public decimal? DiffWeight { get; set; }
        public decimal? iniRealWgt { get; set; }
        public decimal? iniDiffWeight { get; set; }
        public string? BXType { get; set; }
        public double? BXQty { get; set; }
        public string? PBCode { get; set; }
        public string? ColorLevel { get; set; }
        public string? SubTransfer { get; set; }
    }
}
