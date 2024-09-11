using Dapper;
using Microsoft.Data.SqlClient;
using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Core.Objects;
using Source.Core.Parameters;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Source.Core.DTOs;

namespace Source.Infrastructure.Repositories
{
    public class ExtensionsRepository : GenericRepository, IExtensionsRepository, IGenericRepository
    {
        public ExtensionsRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<string>> GetDeptDataImex()
        {
            var _result = await base.QueryAsync<string>(
                @"select distinct Dept FROM [dbo].[DATA_IMEX] with(nolock)", null, "KVTWLConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<List<DataImex>> GetListDataImex(DataImexParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@EmpCode", param.EmpCode ?? "", DbType.String);
            _parameters.Add("@Dept", param.Dept ?? "", DbType.String);
            _parameters.Add("@Description", param.Description ?? "", DbType.String);
            _parameters.Add("@FromDate", param.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", param.ToDate ?? "", DbType.String);
            _parameters.Add("@Item", param.Item ?? "", DbType.String);
            _parameters.Add("@Color", param.Color ?? "", DbType.String);
            _parameters.Add("@Size", param.Size ?? "", DbType.String);
            _parameters.Add("@FullCode", param.FullCode ?? "", DbType.String);

            var _result = await base.QueryAsync<DataImex>(
                @"exec [dbo].[sp_DATA_IMEX_Load_by_web] @EmpCode,@Dept,@Description,@FromDate,@ToDate,@Item,@Color,@Size,@FullCode", _parameters, "KVTWLConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<List<FeedbackProduction>> GetListProductionFeedback(FeedbackParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", param.Barcode ?? "", DbType.String);
            _parameters.Add("@FromDate", param.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", param.ToDate ?? "", DbType.String);

            var _result = await base.QueryAsync<FeedbackProduction>(
                @"exec [dbo].[sp_ProdScanFeedback_Load] @Barcode,@FromDate,@ToDate", _parameters, "HydraConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<List<FeedbackSSBC>> GetListSSBCFeedback(FeedbackParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@FromDate", param.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", param.ToDate ?? "", DbType.String);

            var _result = await base.QueryAsync<FeedbackSSBC>(
                @"exec [dbo].[sp_SSBC_WHS_Feedback_Load] @FromDate,@ToDate", _parameters, "HydraConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<List<ProdScan>> GetListProdScan(ProductionScannerParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@MachineNo", param.MachineNo ?? "", DbType.String);
            _parameters.Add("@Item", param.Item ?? "", DbType.String);
            _parameters.Add("@Shift", param.Shift ?? "", DbType.String);
            _parameters.Add("@Barcode", param.Barcode ?? "", DbType.String);
            _parameters.Add("@FromDate", param.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", param.ToDate ?? "", DbType.String);

            var _result = await base.QueryAsync<ProdScan>(
                @"exec [dbo].[sp_ProdScan_Load_Report] @MachineNo,@Item,@Shift,@Barcode,@FromDate,@ToDate", _parameters, "HydraConnection"
            );
            return _result.ToList();
        }

        public async Task<int> DeleteProdScan(string Barcode, string UserName)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode ?? "", DbType.String);

            return await base.ExecuteAsync(
                    @"delete from ProdScan where Barcode=@Barcode", _parameters, "HydraConnection"
            );
        }

        public async Task<List<Component>> GetListProdComp(ComponentParameter param)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@WhsType", param.Whs ?? "", DbType.String);
            _parameters.Add("@Item", param.Item ?? "", DbType.String);
            _parameters.Add("@CompType", param.MachineNo ?? "", DbType.String);
            _parameters.Add("@Color", param.Color ?? "", DbType.String);
            _parameters.Add("@Size", param.Size ?? "", DbType.String);
            _parameters.Add("@FromDate", param.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", param.ToDate ?? "", DbType.String);

            var _result = await base.QueryAsync<Component>(
                @"exec [dbo].[sp_Prod_Components_WhsIn_Tracking] @WhsType,@Item, @Color, @Size, @CompType, @FromDate, @ToDate", _parameters, "KVTWLConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<List<DropDowList>> CompTypeLoadDropdown(string type)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@type", type, DbType.String);

            var _result = await base.QueryAsync<DropDowList>(
                @"exec [dbo].[sp_Prod_Components_Get_DropDownList] @type", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<ItemFullCodeDropdown>> CompFullCodeLoadDropdown(string type)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@type", type, DbType.String);

            var _result = await base.QueryAsync<ItemFullCodeDropdown>(
                @"exec [dbo].[sp_Prod_Components_Get_DropDownList] @type", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<Component?> AddProdComp(Component comp)
        {
            var _parameters = new DynamicParameters();
            //_parameters.Add("@MachineNo", param.MachineNo ?? "", DbType.String);
            _parameters.Add("@Item", comp.ItemCode ?? "", DbType.String);
            _parameters.Add("@CompType", comp.CompType ?? "", DbType.String);
            _parameters.Add("@Color", comp.ColorCode ?? "", DbType.String);
            _parameters.Add("@Size", comp.SizeCode ?? "", DbType.String);
            _parameters.Add("@MachineNo", comp.MachineNo ?? "", DbType.String);
            _parameters.Add("@Qty", comp.Qty ?? 0, DbType.Int64);
            _parameters.Add("@Remark", comp.Remark ?? "", DbType.String);
            _parameters.Add("@CreateBy", comp.CreateBy ?? "", DbType.String);

            var _result = await base.QueryAsync<Component>(
                @"exec [dbo].[sp_Prod_Components_WhsIn_Update] @CompType, @Item, @Color, @Size, @MachineNo, @Qty, @Remark, @CreateBy", _parameters, "KVTWLConnection"
            );

            return _result.FirstOrDefault();
        }

        public async Task<Component?> ProdCompInGetById(string TrackNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", TrackNo, DbType.String);

            var _result = await base.QueryAsync<Component>(
              @"exec [dbo].[sp_Prod_Components_WhsIn_ByID] @Barcode", _parameters, "KVTWLConnection"
           );
            return _result.FirstOrDefault();
        }

        public async Task<SqlResultDTO?> ProdCompOut(Component comp)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", comp.TrackNo ?? "", DbType.String);
            _parameters.Add("@DateOut", comp.OutDate, DbType.DateTime);
            _parameters.Add("@Remark", comp.Remark, DbType.String);
            _parameters.Add("@InputM", comp.CreateBy, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
               @"exec [dbo].[sp_Prod_Components_WhsOut_Update] @Barcode,@DateOut,@Remark, @InputM", _parameters, "KVTWLConnection"
            );
            return _result.FirstOrDefault();
        }
    }
}
