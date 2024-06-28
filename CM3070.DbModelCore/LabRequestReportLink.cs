using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class LabRequestReportLink
    {
        public int id { get; set; }
        public string request_table { get; set; }
        public Nullable<int> request_id { get; set; }
        public Nullable<System.DateTime> request_date { get; set; }
        public string report_table { get; set; }
        public int report_id { get; set; }
    }
}
