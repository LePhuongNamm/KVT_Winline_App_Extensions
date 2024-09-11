using OfficeOpenXml.Table;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace Source.WebUI.Utils
{
    public static class EPPlusExtensions
    {
        public static async Task<DataTable> Read(IFileReference file)
        {
            DataTable dt = new DataTable();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var fileInfo = await file.ReadFileInfoAsync();
            var stream = await file.CreateMemoryStreamAsync((int)fileInfo.Size);
            var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            var package = new ExcelPackage(memoryStream);
            var currentSheet = package.Workbook.Worksheets;
            var ws = currentSheet.First();
            bool hasHeader = true;
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = dt.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return dt;
        }

        public static byte[] Write(DataTable dt, string Title)
        {
            var memoryStream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!string.IsNullOrEmpty(Title))
            {
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].Value = Title;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A2"].LoadFromDataTable(dt, true, TableStyles.None);
                    worksheet.Cells["A2:AN2"].Style.Font.Bold = true;
                    worksheet.DefaultRowHeight = 18;
                    return excelPackage.GetAsByteArray();
                }
            }
            else
            {
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.None);
                    worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
                    worksheet.DefaultRowHeight = 18;
                    return excelPackage.GetAsByteArray();
                }
            }
        }
    }
}
