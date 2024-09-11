using Source.Core.Contracts.Basic;
using Source.Core.Contracts;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Source.Core.Objects;
using Source.Core.Parameters;
using System.Data;

namespace Source.Infrastructure.Repositories
{
    public class QACRepository : GenericRepository, IQACRepository, IGenericRepository
    {
        public QACRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<Qc_SSBC_WhsIn>> SSBCWhsInViewWL(QCSSBCWhsParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@SubName", parameter.SubName ?? "", DbType.String);
            _parameters.Add("@FromDate", parameter.FromDate ?? DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
            _parameters.Add("@ToDate", parameter.ToDate ?? DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);
            _parameters.Add("@Size", parameter.Size ?? "", DbType.String);

            var _result = await base.QueryAsync<Qc_SSBC_WhsIn>(
                @"exec [dbo].[sp_QAC_SSBC_WhsIn_view_WL] @SubName,@FromDate,@ToDate,@Item,@Size,@Color", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<Qc_SSBC_WhsIn>> SSBCWhsExchangeQcViewWL(QCSSBCWhsParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@Action", parameter.Type ?? "", DbType.String);
            _parameters.Add("@FromDate", parameter.FromDate ?? DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
            _parameters.Add("@ToDate", parameter.ToDate ?? DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);
            _parameters.Add("@Size", parameter.Size ?? "", DbType.String);

            var _result = await base.QueryAsync<Qc_SSBC_WhsIn>(
                @"exec [dbo].[sp_QAC_SSBC_WhsExchangeQC_view_WL] @Action,@FromDate,@ToDate,@Item,@Size,@Color", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }

        public async Task<List<ColorPrepartionPlan>> ColorPrepartionPlanReport(ColorPrepartionPlanParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@FormDate", parameter.FormDate ?? DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
            _parameters.Add("@ToDate", parameter.ToDate ?? DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);

            var _result = await base.QueryAsync<ColorPrepartionPlan>(
                @"exec [dbo].[sp_QAC_Color_Swatch_Prepartion_Plan] @FormDate,@ToDate,@Item,@Color", _parameters, "KVTWLConnection"
            );
            return _result.ToList();
        }
    }
}
