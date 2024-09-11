using Source.Core.DTOs;
using Source.Core.Objects;
using Source.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts
{
    public interface IExtensionsRepository
    {
        Task<List<string>> GetDeptDataImex();
        Task<List<DataImex>> GetListDataImex(DataImexParameter param);
        Task<List<FeedbackProduction>> GetListProductionFeedback(FeedbackParameter param);
        Task<List<FeedbackSSBC>> GetListSSBCFeedback(FeedbackParameter param);
        Task<List<ProdScan>> GetListProdScan(ProductionScannerParameter param);
        Task<int> DeleteProdScan(string Barcode, string UserName);
        Task<List<Component>> GetListProdComp(ComponentParameter param);
        Task<List<DropDowList>> CompTypeLoadDropdown(string type);
        Task<List<ItemFullCodeDropdown>> CompFullCodeLoadDropdown(string type);
        Task<Component?> AddProdComp(Component comp);
        Task<Component?> ProdCompInGetById(string TrackNo);
        Task<SqlResultDTO?> ProdCompOut(Component comp);
    }
}
