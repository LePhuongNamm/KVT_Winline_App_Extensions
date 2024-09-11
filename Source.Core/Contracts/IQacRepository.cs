using Source.Core.Objects;
using Source.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts
{
    public interface IQACRepository
    {
        Task<List<Qc_SSBC_WhsIn>> SSBCWhsInViewWL(QCSSBCWhsParameter parameter);
        Task<List<Qc_SSBC_WhsIn>> SSBCWhsExchangeQcViewWL(QCSSBCWhsParameter parameter);
        Task<List<ColorPrepartionPlan>> ColorPrepartionPlanReport(ColorPrepartionPlanParameter parameter);
    }
}
