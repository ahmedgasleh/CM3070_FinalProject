using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class Tickler
    {
        public int tickler_no { get; set; }
        public Nullable<int> demographic_no { get; set; }
        public Nullable<int> program_id { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<System.DateTime> service_date { get; set; }
        public string creator { get; set; }
        public string priority { get; set; }
        public string task_assigned_to { get; set; }
        public Nullable<int> category_id { get; set; }
    }
}
