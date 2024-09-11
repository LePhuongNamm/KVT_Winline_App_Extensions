using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.WebUI.Utils
{
    public static class BarcodeHandleExtensions
    {
        public static string Generator(string value)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.L);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            return Convert.ToBase64String(qRCode.GetGraphic(20, false));
        }
    }
}
