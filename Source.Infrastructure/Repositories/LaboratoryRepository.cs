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
    public class LaboratoryRepository : GenericRepository, ILaboratoryRepository, IGenericRepository
    {
        public LaboratoryRepository(SqlConnectionFactory conn) : base(conn) { }

        public async Task<List<LabTest>> GetAll(LabTestParameter parameter)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@No", parameter.No ?? "", DbType.String);
            _parameters.Add("@Item", parameter.Item ?? "", DbType.String);
            _parameters.Add("@Color", parameter.Color ?? "", DbType.String);

            var _result = await base.QueryAsync<LabTest>(
                @"exec [dbo].[sp_LapTest_load] @No,@Item,@Color", _parameters, "KVTWLConnection"
            );
            return _result.AsEnumerable().ToList();
        }

        public async Task<int> CheckItemColorCode(string ItemColorCode)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@ItemColorCode", ItemColorCode, DbType.String);

            var _result = await base.QueryAsync<int>(
                @"exec [dbo].[sp_LapTest_check_item_color] @ItemColorCode", _parameters, "KVTWLConnection"
            );
            return _result.AsQueryable().FirstOrDefault();
        }

        public async Task Import(LabTest obj, string userName)
        {
            var _parameters = new DynamicParameters();
            _parameters.Add("@No", obj.No ?? "", DbType.String);
            _parameters.Add("@ItemCode", obj.ItemCode ?? "", DbType.String);
            _parameters.Add("@ColorCode", obj.ColorCode ?? "", DbType.String);
            _parameters.Add("@TestingTime", obj.TestingTime ?? "", DbType.String);
            _parameters.Add("@Improve", obj.Improve ?? "", DbType.String);
            _parameters.Add("@OverallTestResult", obj.OverallTestResult ?? "", DbType.String);
            _parameters.Add("@LabTestResultDate", obj.LabTestResultDate ?? "", DbType.String);
            _parameters.Add("@Note", obj.Note ?? "", DbType.String);
            _parameters.Add("@Material", obj.MaterialCode ?? "", DbType.String);
            _parameters.Add("@QUV_QUVMark", obj.QUV_QUVMark ?? "", DbType.String);
            _parameters.Add("@QUV_InternalQUVTestResult30", obj.QUV_InternalQUVTestResult30 ?? "", DbType.String);
            _parameters.Add("@QUV_NikeQUVTestResult35", obj.QUV_NikeQUVTestResult35 ?? "", DbType.String);
            _parameters.Add("@CM_InternalMark", obj.CM_InternalMark ?? "", DbType.String);
            _parameters.Add("@CM_IMResult", obj.CM_IMResult ?? "", DbType.String);
            _parameters.Add("@CM_NikeMark", obj.CM_NikeMark ?? "", DbType.String);
            _parameters.Add("@CM_NMResult", obj.CM_NMResult ?? "", DbType.String);
            _parameters.Add("@CM_FinalResult", obj.CM_FinalResult ?? "", DbType.String);
            _parameters.Add("@A_AgingMark", obj.A_AgingMark ?? "", DbType.String);
            _parameters.Add("@A_Result", obj.A_Result ?? "", DbType.String);
            _parameters.Add("@H_Mark", obj.H_Mark ?? "", DbType.String);
            _parameters.Add("@H_Result", obj.H_Result ?? "", DbType.String);
            _parameters.Add("@CRF_Cycle", obj.CRF_Cycle ?? "", DbType.String);
            _parameters.Add("@CRF_Result", obj.CRF_Result ?? "", DbType.String);
            _parameters.Add("@B_Score", obj.B_Score ?? "", DbType.String);
            _parameters.Add("@B_Result", obj.B_Result ?? "", DbType.String);
            _parameters.Add("@Box", obj.Box ?? "", DbType.String);
            _parameters.Add("@userName", userName, DbType.String);

            await base.ExecuteAsync(
                @"exec [dbo].[sp_LapTest_import] @No, @ItemCode,@ColorCode,@TestingTime ,@Improve, @OverallTestResult,@LabTestResultDate, @Note,
                                                 @Material, @QUV_QUVMark,@QUV_InternalQUVTestResult30,@QUV_NikeQUVTestResult35,@CM_InternalMark,@CM_IMResult,@CM_NikeMark, @CM_NMResult,@CM_FinalResult, @A_AgingMark,
                                                 @A_Result, @H_Mark,@H_Result,@CRF_Cycle,@CRF_Result,@B_Score ,@B_Result, @Box,@userName", 
                _parameters, "KVTWLConnection"
            );
        }
    }
}
