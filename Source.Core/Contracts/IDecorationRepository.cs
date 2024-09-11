using Source.Core.DTOs;
using Source.Core.Objects;
using Source.Core.Parameters;

namespace Source.Core.Contracts
{
    public interface IDecorationRepository
    {
        Task<List<SubControl>> GetListSubTracking(SubTrackingParameter parameter);
        Task<SqlResultDTO> ImportSubTracking(string Barcode, string SubTransfer, string DateTransfer, string UpdateBy);
        Task<int> DeleteSubTracking(string Barcode, string UpdateBy);
        Task<SqlResultDTO> CheckSubTracking(string Barcode);
    }
}
