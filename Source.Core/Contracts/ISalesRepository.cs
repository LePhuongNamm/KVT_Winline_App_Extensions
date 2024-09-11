using Source.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts
{
    public interface ISalesRepository
    {
        Task<string?> GetEtdOldByOrderNo(string OrderNo);
        Task<string?> GetPriceOldByOrderNo(string OrderNo);
        Task<int?> CheckCodeImportHistory(string CodeImport);
        Task InsertHistory(TblETDChangeHistory obj);
        Task DeleteHistory(string CodeImport);
        Task ChangeETDToWL(string CodeImport);
        Task ChangePriceToWL(string CodeImport);
        Task ChangePriceForDnToWL(string CodeImport);
        Task<List<BoxOverviewSelect>> BoxOverviewSelect();
        Task<int> BoxOverviewImport(BoxOverviewSelect source);
    }
}
