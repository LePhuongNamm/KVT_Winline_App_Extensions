using Dapper;
using Microsoft.Data.SqlClient;
using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Core.DTOs;
using Source.Core.Objects;
using Source.Core.Parameters;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Source.Infrastructure.Repositories
{
    public class AcsFilmRepository : GenericRepository, IAcsFilmRepository, IGenericRepository
    {
        public AcsFilmRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<V_PACKING>> GetPackingInfo(string pakingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", pakingNo ?? "", DbType.String);

            var _result = await base.QueryAsync<V_PACKING>(
                @"SELECT * FROM [FKVQAC].[dbo].[V_PACKING] WITH(NOLOCK) WHERE PackingNo = @PackingNo", _parameters, "QACConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<string?> GetPackingNo(string OrderType)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@OrderType", OrderType ?? "", DbType.String);

            var _result = await base.QueryAsync<string>(
               @"exec [dbo].[sp_PPICOrder_Get_PakingNo] @OrderType", _parameters, "QACConnection"
            );

            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task PPICOrderDetailInsert(string pakingNo, V_PACKING obj, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", pakingNo ?? "", DbType.String);
            _parameters.Add("@SAOrderNo", obj.PackingNo ?? "", DbType.String);
            _parameters.Add("@SAItemFullCode", obj.ItemFullCode ?? "", DbType.String);
            _parameters.Add("@OrderType", obj.OrderType ?? "", DbType.String);
            _parameters.Add("@SAOrderQty", obj.QtyOrder ?? 0, DbType.Double);
            _parameters.Add("@ItemCode", obj.ItemCode ?? "", DbType.String);
            _parameters.Add("@ItemName", obj.ItemName ?? "", DbType.String);
            _parameters.Add("@ColorCode", obj.ColorCode ?? "", DbType.String);
            _parameters.Add("@ColorName", obj.ColorName ?? "", DbType.String);
            _parameters.Add("@SizeCode", obj.SizeCode ?? "", DbType.String);
            _parameters.Add("@SizeName", obj.SizeName ?? "", DbType.String);
            _parameters.Add("@User", user, DbType.String);

            await base.ExecuteAsync(
                @"exec [dbo].[sp_PPICOrderDetail_Insert] @PackingNo, @SAOrderNo,@SAItemFullCode,@OrderType ,@SAOrderQty, @ItemCode,
                  @ItemName, @ColorCode,@ColorName, @SizeCode,@SizeName,@User", _parameters, "QACConnection"
            );
        }

        public async Task PPICOrderDetailDelete(string pakingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", pakingNo ?? "", DbType.String);

            await base.ExecuteAsync(
                @"delete FROM [FKVQAC].[dbo].[PPICOrderDetail] where PackingNo = @PackingNo", _parameters, "QACConnection"
            );
        }

        public async Task<SqlResultDTO?> PPICOrderInsertMan(string pakingNo, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", pakingNo ?? "", DbType.String);
            _parameters.Add("@InputM", user, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_PPICOrder_Insert] @PackingNo, @InputM", _parameters, "QACConnection"
            );

            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task PPICOrderInsertLoss(string pakingNo, string user, FilmPPICOrder obj)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", pakingNo ?? "", DbType.String);
            _parameters.Add("@ItemFullCode", obj.ItemFullCode ?? "", DbType.String);
            _parameters.Add("@OrderType", obj.OrderType ?? 0, DbType.Int32);
            _parameters.Add("@MainOrder", obj.MainOrder ?? "", DbType.String);
            _parameters.Add("@OrderQty", obj.OrderQtyNew ?? 0, DbType.Int32);
            _parameters.Add("@ItemCode", obj.ItemCode ?? "", DbType.String);
            _parameters.Add("@ItemName", obj.ItemName ?? "", DbType.String);
            _parameters.Add("@ColorCode", obj.ColorCode ?? "", DbType.String);
            _parameters.Add("@ColorName", obj.ColorName ?? "", DbType.String);
            _parameters.Add("@SizeCode", obj.SizeCode ?? "", DbType.String);
            _parameters.Add("@SizeName", obj.SizeName ?? "", DbType.String);
            _parameters.Add("@UserIn", user, DbType.String);

            await base.ExecuteAsync(
               @"exec [dbo].[sp_PPICOrder_Insert_Loss] @PackingNo, @ItemFullCode,@OrderType,@MainOrder ,@OrderQty, @ItemCode,
                 @ItemName, @ColorCode,@ColorName, @SizeCode,@SizeName,@UserIn", _parameters, "QACConnection"
            );
        }

        public async Task<SqlResultDTO?> ProdOrderInsert(string pakingNo, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", pakingNo ?? "", DbType.String);
            _parameters.Add("@InputM", user, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_ProdOrder_Insert] @PackingNo, @InputM", _parameters, "QACConnection"
            );

            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task<List<FilmPPICOrder>> PPICOrderLoad(OrderRegisterLossParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Type", param.Type ?? "", DbType.String);
            _parameters.Add("@PackingNo", param.PackingNo ?? "", DbType.String);

            var _result = await base.QueryAsync<FilmPPICOrder>(
               @"exec [dbo].[sp_PPICOrder_Load] @Type,@PackingNo", _parameters, "QACConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<List<FilmProdOrder>> ProdOrderLoad(FilmProdOrderParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ProdOrderNo", param.ProdOrderNo ?? "", DbType.String);
            _parameters.Add("@PackingNo", param.PackingNo ?? "", DbType.String);
            _parameters.Add("@Barcode", param.Barcode ?? "", DbType.String);
            _parameters.Add("@ScanStatus", param.ScanStatus ?? "", DbType.String);

            var _result = await base.QueryAsync<FilmProdOrder>(
               @"exec [dbo].[sp_ProdOrder_Load] @ProdOrderNo,@PackingNo,@Barcode,@ScanStatus", _parameters, "QACConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<SqlResultDTO?> ProdOrderLabelDivide(FilmProdOrder obj, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", obj.Barcode ?? "", DbType.String);
            _parameters.Add("@QtyDV", obj.OrderQtyNew ?? 0, DbType.Int32);
            _parameters.Add("@UpdatM", user, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_ProdOrder_Label_Divide] @Barcode,@QtyDV,@UpdatM", _parameters, "QACConnection"
            );

            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task<FilmProdOrder?> ProdOrderLoadByBarcode(string Barcode)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode, DbType.String);

            var _result = await base.QueryAsync<FilmProdOrder>(
               @"exec [dbo].[sp_ProdOrder_Load_By_Barcode] @Barcode", _parameters, "QACConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task<SqlResultDTO?> ProdScannerCheck(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
              @"exec [dbo].[sp_ProdScanned_Check] @CodeImport", _parameters, "QACConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task ProdScannerInsert(string CodeImport, string Barcode, string OptionInput, string user)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ImportCode", CodeImport, DbType.String);
            _parameters.Add("@Barcode", Barcode , DbType.String);
            _parameters.Add("@OptionInput", OptionInput, DbType.String);
            _parameters.Add("@InputM", user, DbType.String);

            await base.ExecuteAsync(
               @"exec [dbo].[sp_ProdScanned_Insert] @ImportCode,@Barcode,@OptionInput, @InputM", _parameters, "QACConnection"
            );
        }

        public async Task<SqlResultDTO?> ProdScannerConfirm(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
              @"exec [dbo].[sp_ProdOrder_Stock_Scan] @CodeImport", _parameters, "QACConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task ProdScannedDeleteByCodeImport(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            await base.ExecuteAsync(
               @"delete FROM [dbo].[ProdScanned] where ImportCode = @CodeImport", _parameters, "QACConnection"
            );
        }
    }
}
