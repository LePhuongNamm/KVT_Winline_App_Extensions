using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Core.DTOs;
using Source.Core.Objects;
using Source.Core.Parameters;
using Dapper;
using System.Data;
using System.Reflection.Metadata;
using System.Data.Common;

namespace Source.Infrastructure.Repositories
{
    public class DecorationRepository : GenericRepository, IDecorationRepository, IGenericRepository
    {
        public DecorationRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<SubControl>> GetListSubTracking(SubTrackingParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@SubName", parameter.SubName ?? "", DbType.String);
            _parameters.Add("@Barcode", parameter.Barcode ?? "", DbType.String);
            _parameters.Add("@PackingNo", parameter.PackingNo ?? "", DbType.String);
            _parameters.Add("@Status", parameter.Status ?? "", DbType.String);
            _parameters.Add("@FromDate", parameter.FromDate ?? "", DbType.String);
            _parameters.Add("@ToDate", parameter.ToDate ?? "", DbType.String);
            _parameters.Add("@SubStatus", "", DbType.String);
            _parameters.Add("@IsPrint",  "", DbType.String);
            _parameters.Add("@BarcodeImport", parameter.BarcodeImport ?? "", DbType.String);
            var _result = await base.QueryAsync<SubControl>(
                @"exec [dbo].[sp_SubControl_Load] @SubName,@Barcode,@PackingNo,@Status,@FromDate,@ToDate,@SubStatus,@IsPrint,@BarcodeImport", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<SqlResultDTO> ImportSubTracking(string Barcode, string SubTransfer, string DateTransfer, string UpdateBy)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@SubName", SubTransfer ?? "", DbType.String);
            _parameters.Add("@Barcode", Barcode ?? "", DbType.String);
            _parameters.Add("@DateTransfer", DateTransfer ?? DateTime.Now.ToString(), DbType.String);
            _parameters.Add("@UpdateBy", UpdateBy ?? "", DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
              @"exec [dbo].[sp_SubControl_Import] @SubName,@Barcode,@DateTransfer,@UpdateBy", _parameters, "KVTWLConnection"
            );

            return _result.FirstOrDefault()!;
        }

        public async Task<int> DeleteSubTracking(string Barcode, string UpdateBy)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode ?? "", DbType.String);
            _parameters.Add("@UpdatM", UpdateBy ?? "", DbType.String);

            return await base.ExecuteAsync(
               @"exec [dbo].[sp_SubControl_Delete] @Barcode,@UpdatM",_parameters, "KVTWLConnection"
            );
        }

        public async Task<SqlResultDTO> CheckSubTracking(string Barcode)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Barcode", Barcode, DbType.String);

            var _result = await base.QueryAsync<SqlResultDTO>(
                @"exec sp_SubControl_Check_Barcode @Barcode", _parameters, "KVTWLConnection"
            );

            return _result.FirstOrDefault() ?? new SqlResultDTO { Error = 0 ,Msg = "System Error"};
        }
    }
}
