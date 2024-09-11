using Dapper;
using Microsoft.Data.SqlClient;
using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Core.Objects;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Core.Parameters;
using Source.Core.DTOs;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.FileIO;

namespace Source.Infrastructure.Repositories
{
    public class WarehouseFGRepository : GenericRepository, IWarehouseFGRepository, IGenericRepository
    {
        public WarehouseFGRepository(SqlConnectionFactory conn) : base(conn) { }


        public async Task<List<PakingGlLabel>> FindPackingGlLabel(string? PackingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);

            var _result = await base.QueryAsync<PakingGlLabel>(
                @"exec [dbo].[sp_Packing_GL_Label] @PackingNo", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<OverStationTracking>> FindOverTracking(OverStationTrackingParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ProdOrderNo", parameter.ProdOrderNo ?? "", DbType.String);
            _parameters.Add("@PackingNo", parameter.PackingNo ?? "", DbType.String);
            _parameters.Add("@Customer", parameter.Customer ?? "", DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);
            _parameters.Add("@Size", parameter.Size ?? "", DbType.String);
            _parameters.Add("@FullCode", parameter.FullCode ?? "", DbType.String);
            _parameters.Add("@Type", parameter.Type ?? "", DbType.String);
            _parameters.Add("@InOut", parameter.InOut ?? "", DbType.String);
            _parameters.Add("@FromDate", parameter.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", parameter.ToDate ?? "", DbType.String);
            _parameters.Add("@TakenBy", parameter.TakenBy ?? "", DbType.String);
            _parameters.Add("@Reason", parameter.Reason ?? "", DbType.String);

            var _result = await base.QueryAsync<OverStationTracking>(
                @"exec [dbo].[sp_FG_WHS_Over_Tracking] @ProdOrderNo,@PackingNo,@Customer,@Item,@Color,@Size,@FullCode,@Type,@InOut,@FromDate,@ToDate,@TakenBy,@Reason", 
                _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<WHSInTracking>> FindWhsInTracking(WHSInTrackingParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ProdOrderNo", parameter.ProdOrderNo ?? "", DbType.String);
            _parameters.Add("@PackingNo", parameter.PackingNo ?? "", DbType.String);
            _parameters.Add("@Customer", parameter.Customer ?? "", DbType.String);
            _parameters.Add("@OptionInput", parameter.OptionInput ?? "", DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);
            _parameters.Add("@Size", parameter.Size ?? "", DbType.String);
            _parameters.Add("@FullCode", parameter.FullCode ?? "", DbType.String);
            _parameters.Add("@Scanned", parameter.Scanned ?? "", DbType.String);
            _parameters.Add("@Status", parameter.Status ?? "", DbType.String);
            _parameters.Add("@FromDate", parameter.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", parameter.ToDate ?? "", DbType.String);
            _parameters.Add("@BarcodeImport", parameter.BarcodeImport ?? "", DbType.String);

            var _result = await base.QueryAsync<WHSInTracking>(
                @"exec [dbo].[sp_FG_WHS_In_Tracking] @ProdOrderNo,@PackingNo,@Customer,@OptionInput,@Item,@Color,@Size,@FullCode,@Scanned,@Status,@FromDate,@ToDate,@BarcodeImport",
                _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<SqlResultDTO> DeleteWhsInTracking(string barcodes)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcodes", barcodes, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
                @"exec [dbo].[sp_FG_WHS_In_Delete] @Barcodes", _parameters, "KVTWLConnection"
            );

            return _result.FirstOrDefault() ?? new SqlResultDTO { Error = 1, Msg = "Sql not responding." };
        }

        public async Task<SqlResultDTO> UpdateOptionWhsInTracking(string barcodes,string option)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcodes", barcodes, DbType.String);
            _parameters.Add("@Option", option, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_FG_WHS_In_Update_Option] @Barcodes,@Option", _parameters, "KVTWLConnection"
           );

            return _result.FirstOrDefault() ?? new SqlResultDTO { Error = 1, Msg = "Sql not responding." };
        }

        public async Task<List<WHS_Packing_Delivery>> PackingGetDeliveries(WHS_Packing_Delivery_Parameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@TitleCustomer", parameter.TitleCustomer ?? "", DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);
            _parameters.Add("@Size", parameter.Size ?? "", DbType.String);
            _parameters.Add("@DeliveryDate", parameter.DeliveryDate ?? "", DbType.String);
            _parameters.Add("@DeliveryNote", parameter.DeliveryNote ?? "", DbType.String);
            _parameters.Add("@DPONo", parameter.DPONo ?? "", DbType.String);
            _parameters.Add("@StyleNo", parameter.StyleNo ?? "", DbType.String);

            var _result = await base.QueryAsync<WHS_Packing_Delivery>(
                @"exec [dbo].[sp_FG_WHS_Packing_Delivery_Load] @TitleCustomer,@Item,@Color,@Size,@DeliveryDate,@DeliveryNote,@DPONo,@StyleNo", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<WHS_Packing_SaOrder>> PackingGetSaOrders(List<string> DeliveryNos)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@DeliveryNo", string.Join(",", DeliveryNos), DbType.String);

            var _result = await base.QueryAsync<WHS_Packing_SaOrder>(
                @"exec [dbo].[sp_FG_WHS_Packing_SaOrder_Load] @DeliveryNo", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<WHS_Packing_Details>> PackingDetailLoad(string PackingNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);

            var _result = await base.QueryAsync<WHS_Packing_Details>(
                @"exec [dbo].[sp_FG_WHS_Packing_Detail_Load] @PackingNo", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<SqlResultDTO> PackingDetaiGeneral(string PackingNo, string User, List<string> sources)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);
            _parameters.Add("@InputM", User, DbType.String);
            _parameters.Add("@DeliveryNo", string.Join(",", sources), DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_FG_WHS_Packing_Detail_General] @PackingNo,@InputM,@DeliveryNo", _parameters, "KVTWLConnection"
            );

            return _result.FirstOrDefault() ?? new SqlResultDTO { Error = 1, Msg = "Sql not responding." };
        }

        public async Task<SqlResultDTO> PackingBoxGeneral(string PackingNo, string User)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@PackingNo", PackingNo, DbType.String);
            _parameters.Add("@InputM", User, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
              @"exec [dbo].[sp_FG_WHS_Packing_Box_General] @PackingNo,@InputM", _parameters, "KVTWLConnection"
           );

            return _result.FirstOrDefault() ?? new SqlResultDTO { Error = 1, Msg = "Sql not responding." };
        }
    }
}
