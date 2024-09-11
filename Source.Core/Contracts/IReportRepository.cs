using Source.Core.Objects;
using Source.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts
{
    public interface IReportRepository
    {
        Task<List<ProdPending>> ProdPendingReport(ProdPendingParameter param);
        Task<List<ProductionOrderArticle>> ProductionOrderArticleReport(string IsYear);
        Task<List<RepackingRequest>> RepackingRequestReport(string IsYear);
        Task<DataTable> OrderCheckingReport(OrderCheckingParameter parameter);
    }
}
