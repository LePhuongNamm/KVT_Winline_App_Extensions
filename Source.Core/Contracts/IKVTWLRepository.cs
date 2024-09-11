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
    public interface IKVTWLRepository
    {
        Task<List<BarcodeInfo>> TbProdOrderLoad(TbProdOrderParameter param);
        Task<TbProdOrder?> TbProdOrderLoadByBarcode(string Barcode);
        Task<short> TbProdOrderGetBoxDv(string ProdOrderNo, string Seq, string SubSeq, string BoxCount);
        Task<List<BarcodeInfo>> SortLabelSeparation(string CodeImport);
        Task<SqlResultDTO?> ProdOrderLabelSeparation(string Barcode, double QtyDV, string CodeImport, string user);
        Task<SqlResultDTO?> ProdOrderLabelMerge(string OriginalBarcode, string SplitBarcode, string user);
        Task<List<SeparetionRecord>> LabelSeparationReport(SeparetionRecordParameter param);
        Task UpdatePrinted(string Barcode, string User);
        Task<List<DropDowList>> ScanStatusLoadDropdown(string type);
        Task<List<ItemFullCodeDropdown>> ItemFullCodeLoadDropdown();
        Task<List<string>> GetPackingNoFromProd();
        Task<List<V_PACKING_WL>> GetPackingInfo(string PackingNo);
        Task<SqlResultDTO> RegisterOrder(string PackingNo, string user, string CodeImport);
        Task RollbackOrder(string PackingNo);
        Task<List<TbProdOrder>> ProdOrderLoadAfterRegister(string CodeImport);
    }
}
