using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Source.WebUI.Utils
{
    public static class ImageHandleExtensions
    {
        public static async Task SaveImage(string directory, Stream stream)
        {
            var fileStream = new FileStream(directory, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fileStream);
            fileStream.Dispose();
        }
    }
}
