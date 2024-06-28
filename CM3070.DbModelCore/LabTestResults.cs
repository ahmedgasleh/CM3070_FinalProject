using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class LabTestResults
    {
        public int id { get; set; }
        public Nullable<int> labPatientPhysicianInfo_id { get; set; }
        public string line_type { get; set; }
        public string title { get; set; }
        public string notUsed1 { get; set; }
        public string notUsed2 { get; set; }
        public string test_name { get; set; }
        public string abn { get; set; }
        public string minimum { get; set; }
        public string maximum { get; set; }
        public string units { get; set; }
        public string result { get; set; }
        public string description { get; set; }
        public string location_id { get; set; }
        public string last { get; set; }
    }
}
