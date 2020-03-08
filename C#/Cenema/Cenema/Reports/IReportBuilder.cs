﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenema.Reports
{
    public interface IReportBuilder
    {
        Dictionary<string, object> Parameters { get; set; }
        string BuildReport();
    }
}
