using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.DTOs
{
    public class FileInfoDTO
    {
        public string? FileName { get; set; }
        public Stream? Stream { get; set; }
    }
}
