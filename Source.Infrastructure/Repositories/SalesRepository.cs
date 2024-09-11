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
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Source.Infrastructure.Repositories
{
    public class SalesRepository : GenericRepository, ISalesRepository, IGenericRepository
    {
        public SalesRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<string?> GetEtdOldByOrderNo(string OrderNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@OrderNo", OrderNo, DbType.String);
            _parameters.Add("@Type", "ETD", DbType.String);

            var _result = await base.QueryAsync<DateTime>(
                @"exec [dbo].[sp_ChangeETD_Get_Old] @OrderNo,@Type", _parameters, "KVTWLConnection"
            );

            return _result.AsQueryable().FirstOrDefault().ToString("MM/dd/yyyy");
        }

        public async Task<string?> GetPriceOldByOrderNo(string OrderNo)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@OrderNo", OrderNo, DbType.String);
            _parameters.Add("@Type", "Price", DbType.String);

            var _result = await base.QueryAsync<double>(
                @"exec [dbo].[sp_ChangeETD_Get_Old] @OrderNo,@Type", _parameters, "KVTWLConnection"
            );
            return _result.AsQueryable().FirstOrDefault().ToString();
        }

        public async Task<int?> CheckCodeImportHistory(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            var _result = await base.QueryAsync<int>(
                @"SELECT Count(*) as 'Value' FROM [KVTWL].[dbo].[TblETDChangeHistory] WITH(NOLOCK) WHERE CodeImport = @CodeImport", _parameters, "KVTWLConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task InsertHistory(TblETDChangeHistory obj)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", obj.CodeImport, DbType.String);
            _parameters.Add("@OrderNo", obj.OrderNo ?? "", DbType.String);
            _parameters.Add("@Price", obj.Price ?? (object)DBNull.Value, DbType.Decimal);
            _parameters.Add("@ETD", obj.ETD ?? (object)DBNull.Value, DbType.String);
            _parameters.Add("@PositionText", obj.PositionText ?? "", DbType.String);

            await base.ExecuteAsync(
               @"exec [dbo].[sp_Insert_ChangeETD_History] @CodeImport, @OrderNo,@Price,@ETD ,@PositionText", _parameters, "KVTWLConnection"
            );
        }

        public async Task DeleteHistory(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            await base.ExecuteAsync(
               @"Delete [KVTWL].[dbo].[TblETDChangeHistory] WHERE CodeImport = @CodeImport", _parameters, "KVTWLConnection"
            );
        }

        public async Task ChangeETDToWL(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            await base.ExecuteAsync(
               @"exec [dbo].[sp_ChangeETD_ToWL] @CodeImport", _parameters, "KVTWLConnection"
            );
        }

        public async Task ChangePriceToWL(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            await base.ExecuteAsync(
               @"exec [dbo].[sp_ChangePrice_ToWL] @CodeImport", _parameters, "KVTWLConnection"
            );
        }

        public async Task ChangePriceForDnToWL(string CodeImport)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@CodeImport", CodeImport, DbType.String);

            await base.ExecuteAsync(
               @"exec [dbo].[sp_ChangePriceForDN_ToWL] @CodeImport", _parameters, "KVTWLConnection"
            );
        }

        public async Task<List<BoxOverviewSelect>> BoxOverviewSelect()
        {
            var _result = await base.QueryAsync<BoxOverviewSelect>(
                @"exec [dbo].[sp_Sale_BoxOverview_Select]", null, "KVTWLConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<int> BoxOverviewImport(BoxOverviewSelect obj)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Customer", obj.CUSTOMERCO, DbType.String);
            _parameters.Add("@Pending", obj.Pending, DbType.Int32);

            return await base.ExecuteAsync(
               @"exec [dbo].[sp_Sale_BoxOverview_Import] @Customer,@Pending", _parameters, "KVTWLConnection"
            );
        }
    }
}
