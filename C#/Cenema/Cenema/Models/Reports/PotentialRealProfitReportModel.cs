using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenema.Models.Reports
{
    public class PotentialRealProfitReportModel
    {
        public IEnumerable<PotentialRealProfitReportRow> Rows { get; set; }
    }
}