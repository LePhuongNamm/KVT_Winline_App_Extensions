using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class TbProdOrder
    {
        public string? ProdOrderNo { set; get; }
        public Int16? Seq { set; get; }
        public Int16? SubSeq { set; get; }
        public Int16? BoxCount { set; get; }
        public Int16? BoxDV { set; get; }
        public Int16? BoxTotalCount { set; get; }
        public string? PPScan { set; get; }
        public string? FGScan { set; get; }
        public string? mesoprim { set; get; }
        public string? mesocomp { set; get; }
        public string? mesoyear { set; get; }
        public string? PackingNo { set; get; }
        public string? OrderNumber { set; get; }
        public string? Ordered { set; get; }
        public string? TitelCustomer { set; get; }
        public string? Customer { set; get; }
        public DateTime? CreateDate { set; get; }
        public DateTime? DeliveryDate { set; get; }
        public string? ItemCode { set; get; }
        public string? ItemName { set; get; }
        public int? ColorID { set; get; }
        public string? ColorCode { set; get; }
        public string? ColorName { set; get; }
        public int? SizeID { set; get; }
        public string? SizeCode { set; get; }
        public string? SizeName { set; get; }
        public double? QtyOrder { set; get; }
        public string? StyleNo { set; get; }
        public string? UMSales { set; get; }
        public double? Weight { set; get; }
        public string? MoldSize { set; get; }
        public string? ToolingNo { set; get; }
        public string? CusUsePB { set; get; }
        public string? LR { set; get; }
        public string? PPWeight { set; get; }
        public string? Decoration { set; get; }
        public string? BoxType { set; get; }
        public string? HorizontalSize { set; get; }
        public string? VerticalSize { set; get; }
        public string? SizeGroup { set; get; }
        public string? ArticleNumber { set; get; }
        public string? Check1 { set; get; }
        public string? Gender { set; get; }
        public string? ItemFullCode { set; get; }
        public string? DeliveryNote { set; get; }
        public string? InvoiceNo { set; get; }
        public string? AddOpt1 { set; get; }
        public string? Article { set; get; }
        public string? Season { set; get; }
        public string? PositionText { set; get; }
        public string? UpdatM { set; get; }
        public DateTime? UpdatT { set; get; }
        public string? InputM { set; get; }
        public DateTime? InputT { set; get; }
        public string? T1 { set; get; }
        public string? T2 { set; get; }
        public string? T3 { set; get; }
        public string? T4 { set; get; }
        public string? T5 { set; get; }

        [NotMapped]
        public short? BoxDVMax { set; get; }
    }
}
