﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.DTOs
{
    public class BreadcrumbDTO
    {
        public string Text { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
