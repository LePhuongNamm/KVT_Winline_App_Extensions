using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts.Basic
{
    public interface IWrapperRepository
    {
        IAccountRepository Account { get; }
        IAcsFilmRepository AcsFilm { get; }
        IDecorationRepository Deco { get; }
        IExtensionsRepository Extensions { get; }
        IKVTWLRepository KVTWL { get; }
        ILaboratoryRepository Lab { get; }
        IQACRepository Qac { get; }
        IReportRepository Report { get; }
        ISalesRepository Sales { get; }
        IWarehouseFGRepository WareHouseFG { get; }
    }
}
