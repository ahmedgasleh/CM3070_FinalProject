using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class Chart
    {
        public int chart_no { get; set; }

        public int demographic_no { get; set; }

        public string? docfilename { get; set; }

        public DateTime lastUpdateDate { get; set; }
        
    }
}
