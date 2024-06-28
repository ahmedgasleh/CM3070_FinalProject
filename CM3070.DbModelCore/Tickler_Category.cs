using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class Tickler_Category
    {
        public int id { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
