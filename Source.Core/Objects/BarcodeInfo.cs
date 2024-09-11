using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Objects
{
    public class BarcodeInfo
	{
		public string ProdOrderNo { get; set; } = string.Empty;
		public Int16? Seq { get; set; }
		public Int16? SubSeq { get; set; }
		public Int16? BoxCount { get; set; }
		public Int16? BoxDV { get; set; }
        public Int16? BoxTotalCount { get; set; }
        public double? QtyOrder { get; set; }
        public string? TitelCustomer { get; set; }
        public string? Customer { get; set; }
        public string? FGScan { get; set; }
        public string? PPScan { get; set; }
        public string? Status { get; set; }
        public DateTime? DateINWL { get; set; }
        public DateTime? DateOUTWL { get; set; }
        public string? OSCode { get; set; }
        public int? QtyMax { get; set; }
        public string? ItemName { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public string? UMSales { get; set; }
        public string? Gender { get; set; }
        public string? PositionText { get; set; }
        public string? OrderNumber { get; set; }
		public string? StyleNo { get; set; }
        public string? Ordered { get; set; }
        public string? Printed { get; set; }
        public string? ItemCode { get; set; }
        public int? ColorID { get; set; }
        public int? SizeID { get; set; }
        public string? MoldSize { get; set; }
        public string? Check1 { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? VoucherTypeNo { get; set; }
        public string? AddOpt4 { get; set; }
        public string? ColorCode { get; set; }
        public string? SizeCode { get; set; }
        public string? Decoration { get; set; }
        public string? ItemFullCode { get; set; }
        public string? DeliveryNote { get; set; }
        public string? InvoiceNo { get; set; }
        public string? PB { get; set; }
        public string? PPbag { get; set; }
        public string? PBWeight { get; set; }
        public string? BX1wgt { get; set; }
        public string? BX2wgt { get; set; }
        public string? BX3wgt { get; set; }
        public string? BX4wgt { get; set; }
        public string? BX5wgt { get; set; }
        public string? BX6wgt { get; set; }
        public string? ProdMesoprim { get; set; }
        public string? Partionwgt { get; set; }
        public string? FormWgt { get; set; }
        public string? PE_UW { get; set; }
        public string? FO_UW { get; set; }
        public string? CP_UW { get; set; }
        public string? PRS1CP { get; set; }
        public double? Weight { get; set; }
        public string? QRCode { get; set; }
        public string? UpdatM { get; set; }
        public DateTime? UpdatT { get; set; }
        public string? mesocomp { get; set; }
        public int? mesoyear { get; set; }
        public double? ProdWeight { get; set; }
        public string? ArticleNumber { get; set; }
        public DateTime? DateScan { get; set; }
        public string? InputM { get; set; }
        public DateTime? InputT { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? CusUsePB { get; set; }
        public string? PPWeight { get; set; }
        public string? T1 { get; set; }
        public string? T2 { get; set; }
        public string? T3 { get; set; }
        public string? T4 { get; set; }
        public string? T5 { get; set; }
        public string? Text8 { get; set; }
        public string? Text10 { get; set; }
        public DateTime? DeliveryDate { get; set; }
		public string? PackingNo { get; set; }
		public string? ToolingNo { get; set; } 
        public string? BX1 { get; set; }
		public string? BX2 { get; set; }
		public string? BX3 { get; set; }
		public string? BX4 { get; set; }
		public string? BX5 { get; set; }
		public string? BX6 { get; set; }
		public DateTime? DeliEst { get; set; }
        public string? LR { get; set; }
		public double? PRS1PE { get; set; }
        public string? Metal { get; set; }
		public string? Barcode { get; set; }
        public string? Text11 { get; set; }
        public string? Text9 { get; set; }
        public string? Text1 { get; set; }
        public string? Text12 { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; } = false;
    }
}
