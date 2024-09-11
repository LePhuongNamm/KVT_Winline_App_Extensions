
namespace Source.Core.Parameters
{
    public class TbProdOrderParameter
	{
        public string? ProdOrderNoImport { get; set; }
        public string? ProdOrderNo { get; set; }
        public string? Seq { get; set; }
        public string? SubSeq { get; set; }
        public string? BoxCount { get; set; }
        public string? PackingNo { set; get; }
        public string? Customer { get; set; }
        public string? OrderNumber { get; set; }

        public string? Item { get; set; }
        public string? isPrint { get; set; }
        public string? Size { set; get; }
        public string? Color { get; set; }
        public string? Style { get; set; }

        public string? FGScan { get; set; }
        public string? Status { get; set; }
        public string? BoxType { get; set; }
        public string? PB_Cd { get; set; }
        public string? SortValue { get; set; }
    }
}
