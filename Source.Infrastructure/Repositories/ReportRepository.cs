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
using System.Text;
using System.Threading.Tasks;

namespace Source.Infrastructure.Repositories
{
    public class ReportRepository : GenericRepository, IReportRepository, IGenericRepository
    {
        public ReportRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<ProdPending>> ProdPendingReport(ProdPendingParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@dt_from", parameter.FormDate ?? "", DbType.String);
            _parameters.Add("@dt_to", parameter.ToDate ?? "", DbType.String);
            _parameters.Add("@ProdOrderNo", parameter.ProdOrderNo ?? "", DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Size", parameter.Size ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);
            _parameters.Add("@Status", parameter.Status ?? "", DbType.String);

            var _result = await base.QueryAsync<ProdPending>(
               @"exec [dbo].[sp_KVT_ProdPending_Report] @dt_from,@dt_to,@ProdOrderNo,@Item,@Size,@Color,@Status", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<ProductionOrderArticle>> ProductionOrderArticleReport(string IsYear)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@IsYear", IsYear, DbType.String);

            var _result = await base.QueryAsync<ProductionOrderArticle>(
                @"exec [dbo].[sp_Report_Monthly_OrderArticle] @IsYear", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<RepackingRequest>> RepackingRequestReport(string IsYear)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@IsYear", IsYear, DbType.String);

            var _result = await base.QueryAsync<RepackingRequest>(
                @"exec [dbo].[sp_Report_Monthly_Repacking] @IsYear", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<DataTable> OrderCheckingReport(OrderCheckingParameter parameter)
        {
            await Task.Yield();
            var _result = base.Query(
                $"exec [dbo].[sp_WL_Report_Order_Checking] '{parameter.IsCompany ?? ""}','{parameter.DateDeliveryFrom ?? ""}','{parameter.DateDeliveryTo ?? ""}','{parameter.VoucherType ?? ""}'", 
                "KVTWLConnection"
            );
            return _result;
        }
    }
}
