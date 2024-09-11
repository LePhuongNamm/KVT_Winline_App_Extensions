using Dapper;
using Microsoft.Data.SqlClient;
using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Core.DTOs;
using Source.Core.Objects;
using Source.Core.Parameters;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System.Data;

namespace Source.Infrastructure.Repositories
{
    public class KVTWLRepository : GenericRepository, IKVTWLRepository, IGenericRepository
    {
        public KVTWLRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<BarcodeInfo>> TbProdOrderLoad(TbProdOrderParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ProdOrderNo", !string.IsNullOrEmpty(param.ProdOrderNoImport) ? param.ProdOrderNoImport : param.ProdOrderNo ?? "", DbType.String);
            _parameters.Add("@Seq", param.Seq ?? "", DbType.String);
            _parameters.Add("@SubSeq", param.SubSeq ?? "", DbType.String);
            _parameters.Add("@BoxCount", param.BoxCount ?? "", DbType.String);
            _parameters.Add("@PackingNo", param.PackingNo ?? "", DbType.String);
            _parameters.Add("@Customer", param.Customer ?? "", DbType.String);
            _parameters.Add("@OrderNumber", param.OrderNumber ?? "", DbType.String);
            _parameters.Add("@Item", param.Item ?? "", DbType.String);
            _parameters.Add("@Size", param.Size ?? "", DbType.String);
            _parameters.Add("@Color", param.Color ?? "", DbType.String);
            _parameters.Add("@Style", param.Style ?? "", DbType.String);
            _parameters.Add("@FGScan", param.FGScan ?? "", DbType.String);
            _parameters.Add("@Status", param.Status ?? "", DbType.String);
            _parameters.Add("@BoxType", param.BoxType ?? "", DbType.String);
            _parameters.Add("@PB_Cd", param.PB_Cd ?? "", DbType.String);
            _parameters.Add("@Printed", param.isPrint ?? "", DbType.String);
            _parameters.Add("@CodeImport", "", DbType.String);
            _parameters.Add("@SortValue", param.SortValue ?? "", DbType.String);

            var _result = await base.QueryAsync<BarcodeInfo>(
               @"exec [dbo].[sp_KVT_TbProdOrder_Load] @ProdOrderNo,@Seq,@SubSeq,@BoxCount,@PackingNo,@Customer,
                                      @OrderNumber,@Item,@Size,@Color,@Style,@FGScan,@Status,@BoxType,@PB_Cd,@Printed,@CodeImport,@SortValue", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<TbProdOrder?> TbProdOrderLoadByBarcode(string Barcode)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode, DbType.String);

            var _result = await base.QueryAsync<TbProdOrder>(
              @"select * from TbProdOrder with(nolock) where 
                   'J'+RIGHT(ProdOrderNo,7)+'-'+convert(varchar,seq)+'-'+convert(varchar,SubSeq)+'-'+convert(varchar,BoxCount)+'-'+convert(varchar,BoxDV)=@Barcode", _parameters, "KVTWLConnection"
            );
            return _result.FirstOrDefault();
        }

        public async Task<short> TbProdOrderGetBoxDv(string ProdOrderNo, string Seq, string SubSeq, string BoxCount)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ProdOrderNo", ProdOrderNo, DbType.String);
            _parameters.Add("@Seq", Seq, DbType.String);
            _parameters.Add("@SubSeq", SubSeq, DbType.String);
            _parameters.Add("@BoxCount", BoxCount, DbType.String);

            var _result = await base.QueryAsync<short>(
              @"select MAX(BoxDV)+1 from TbProdOrder with(nolock) where ProdOrderNo=@ProdOrderNo and Seq=@Seq and SubSeq=@SubSeq and BoxCount=@BoxCount", _parameters, "KVTWLConnection"
            );
            return _result.FirstOrDefault();
        }

        public async Task<List<BarcodeInfo>> SortLabelSeparation(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ProdOrderNo", "", DbType.String);
            _parameters.Add("@Seq", "", DbType.String);
            _parameters.Add("@SubSeq", "", DbType.String);
            _parameters.Add("@BoxCount", "", DbType.String);
            _parameters.Add("@PackingNo", "", DbType.String);
            _parameters.Add("@Customer", "", DbType.String);
            _parameters.Add("@OrderNumber", "", DbType.String);
            _parameters.Add("@Item", "", DbType.String);
            _parameters.Add("@Size", "", DbType.String);
            _parameters.Add("@Color", "", DbType.String);
            _parameters.Add("@Style", "", DbType.String);
            _parameters.Add("@FGScan", "", DbType.String);
            _parameters.Add("@Status", "", DbType.String);
            _parameters.Add("@BoxType", "", DbType.String);
            _parameters.Add("@PB_Cd", "", DbType.String);
            _parameters.Add("@Printed", "", DbType.String);
            _parameters.Add("@CodeImport", CodeImport, DbType.String);
            _parameters.Add("@SortValue", "", DbType.String);

            var _result = await base.QueryAsync<BarcodeInfo>(
               @"exec [dbo].[sp_KVT_TbProdOrder_Load] @ProdOrderNo,@Seq,@SubSeq,@BoxCount,@PackingNo,@Customer,
                                      @OrderNumber,@Item,@Size,@Color,@Style,@FGScan,@Status,@BoxType,@PB_Cd,@Printed,@CodeImport,@SortValue", _parameters, "KVTWLConnection"
           );
            return _result.ToList();
        }

        public async Task<SqlResultDTO?> ProdOrderLabelSeparation(string Barcode, double QtyDV, string CodeImport, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode ?? "", DbType.String);
            _parameters.Add("@QtyDV",  QtyDV, DbType.Double);
            _parameters.Add("@UpdateM", user, DbType.String);
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_KVT_Label_Separation] @Barcode,@QtyDV,@UpdateM,@CodeImport", _parameters, "KVTWLConnection"
            );
            return _result.FirstOrDefault();
        }

        public async Task<SqlResultDTO?> ProdOrderLabelMerge(string OriginalBarcode, string SplitBarcode, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@OriginalBarcode", OriginalBarcode, DbType.String);
            _parameters.Add("@SplitBarcode", SplitBarcode, DbType.String);
            _parameters.Add("@UpdateM", user, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_KVT_Label_Merge] @OriginalBarcode,@SplitBarcode,@UpdateM", _parameters, "KVTWLConnection"
            );
            return _result.FirstOrDefault();
        }

        public async Task<List<SeparetionRecord>> LabelSeparationReport(SeparetionRecordParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@fromdate", parameter.FormDate ?? "", DbType.String);
            _parameters.Add("@todate", parameter.ToDate ?? "", DbType.String);
            _parameters.Add("@oversea", parameter.Oversea ?? "", DbType.String);
            _parameters.Add("@barcode", parameter.Barcode ?? "", DbType.String);

            var _result = await base.QueryAsync<SeparetionRecord>(
                @"exec [dbo].[sp_KVT_Label_Separation_Report] @fromdate,@todate,@oversea,@barcode", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }


        public async Task UpdatePrinted(string Barcode,string User)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode, DbType.String);
            _parameters.Add("@InputM", User, DbType.String);

            await base.ExecuteAsync(
                @"exec [dbo].[sp_KVT_Update_Printed] @Barcode,@InputM", _parameters, "KVTWLConnection"
            );
        }

        public async Task<List<DropDowList>> ScanStatusLoadDropdown(string type)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@type", type, DbType.String);

            var _result = await base.QueryAsync<DropDowList>(
                @"exec [dbo].[sp_KVT_Get_DropdownList] @type", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<ItemFullCodeDropdown>> ItemFullCodeLoadDropdown()
        {
            var _result = await base.QueryAsync<ItemFullCodeDropdown>(
                @"select ItemCode,ItemName,SizeCode,SizeName,ColorCode,ColorName from TbProdOrder with(nolock) 
                  Group by ItemCode,ItemName,SizeCode,SizeName,ColorCode,ColorName", null, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<string>> GetPackingNoFromProd()
        {
            var _result = await base.QueryAsync<string>(
               @"Select distinct PackingNo from TbProdOrder with(nolock)", null!, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<V_PACKING_WL>> GetPackingInfo(string PackingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);

            var _result = await base.QueryAsync<V_PACKING_WL>(
               @"exec [dbo].[sp_KVT_Order_Get_Packing_Info] @PackingNo", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<SqlResultDTO> RegisterOrder(string PackingNo, string user, string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);
            _parameters.Add("@InputM", user, DbType.String);
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_KVT_Order_Register] @PackingNo,@InputM,@CodeImport", _parameters, "KVTWLConnection"
            );

            return _result.FirstOrDefault()!;
        }

        public async Task RollbackOrder(string PackingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);

            await base.ExecuteAsync(
                @"exec [dbo].[sp_KVT_Order_Rollback] @PackingNo", _parameters, "KVTWLConnection"
            );
        }

        public async Task<List<TbProdOrder>> ProdOrderLoadAfterRegister(string PackingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);

            var _result = await base.QueryAsync<TbProdOrder>(
               @"select * from TbProdOrder with(nolock) where PackingNo in (SELECT value FROM STRING_SPLIT(@PackingNo,',')) ORDER BY ProdOrderNo,Seq,SubSeq,BoxCount,BoxDV", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }
    }
}
