using System.Globalization;

namespace Source.WebUI.Utils
{
    public static class ConvertHelper
    {
        public static string ConvertDateFromExcel(string excelDate)
        {
            string sdat = "";
            DateTime dat;
            sdat = ((string.IsNullOrEmpty(excelDate)) ? sdat : excelDate);
            if (IsDouble(sdat))
            {
                dat = DateTime.FromOADate(double.Parse(sdat));
            }
            else
            {
                if (sdat.Contains(":"))
                {
                    sdat = sdat.Split(' ')[0];
                }
                dat = DateTime.ParseExact(sdat, "M/d/yyyy", CultureInfo.InvariantCulture);
            }
            return dat.ToString("MM/dd/yyyy");
        }

        public static bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }
    }
}
