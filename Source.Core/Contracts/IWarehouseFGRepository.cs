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
    public interface IWarehouseFGRepository
    {
        Task<List<PakingGlLabel>> FindPackingGlLabel(string? PackingNo);
        Task<List<OverStationTracking>> FindOverTracking(OverStationTrackingParameter parameter);
        Task<List<WHSInTracking>> FindWhsInTracking(WHSInTrackingParameter parameter);
        Task<SqlResultDTO> DeleteWhsInTracking(string barcodes);
        Task<SqlResultDTO> UpdateOptionWhsInTracking(string barcodes, string option);
        Task<List<WHS_Packing_Delivery>> PackingGetDeliveries(WHS_Packing_Delivery_Parameter parameter);
        Task<List<WHS_Packing_SaOrder>> PackingGetSaOrders(List<string> DeliveryNos);
        Task<List<WHS_Packing_Details>> PackingDetailLoad(string PackingNo);
        Task<SqlResultDTO> PackingDetaiGeneral(string PackingNo,string User,List<string> sources);
        Task<SqlResultDTO> PackingBoxGeneral(string PackingNo, string User);
    }
}
