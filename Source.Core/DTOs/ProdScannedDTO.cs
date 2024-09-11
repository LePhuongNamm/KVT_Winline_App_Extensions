using Source.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.DTOs
{
    public class ProdScannedDTO
    {
        public string ImportCode { get; set; } = "";
        public string OptionInput { get; set; } = "";
        public List<FilmProdOrder> ProdOrders { get; set; } = new List<FilmProdOrder>();
    }
}
