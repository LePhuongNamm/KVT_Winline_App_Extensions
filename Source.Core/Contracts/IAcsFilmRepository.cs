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
    public interface IAcsFilmRepository
    {
        Task<List<V_PACKING>> GetPackingInfo(string pakingNo);
        Task<string?> GetPackingNo(string OrderType);
        Task PPICOrderDetailInsert(string pakingNo, V_PACKING obj, string user);
        Task PPICOrderDetailDelete(string pakingNo);
        Task<SqlResultDTO?> PPICOrderInsertMan(string pakingNo, string user);
        Task PPICOrderInsertLoss(string pakingNo, string user, FilmPPICOrder obj);
        Task<SqlResultDTO?> ProdOrderInsert(string pakingNo, string user);
        Task<List<FilmPPICOrder>> PPICOrderLoad(OrderRegisterLossParameter param);
        Task<List<FilmProdOrder>> ProdOrderLoad(FilmProdOrderParameter param);
        Task<SqlResultDTO?> ProdOrderLabelDivide(FilmProdOrder obj, string user);
        public Task<FilmProdOrder?> ProdOrderLoadByBarcode(string Barcode);
        public Task ProdScannerInsert(string CodeImport, string Barcode, string OptionInput, string user);
        public Task<SqlResultDTO?> ProdScannerCheck(string CodeImport);
        Task<SqlResultDTO?> ProdScannerConfirm(string CodeImport);
        Task ProdScannedDeleteByCodeImport(string CodeImport);
    }
}
