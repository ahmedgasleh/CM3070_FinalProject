using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class LabPatientPhysicianInfo
    {
        public int id { get; set; }
        public Nullable<int> labReportInfo_id { get; set; }
        public string accession_num { get; set; }
        public string physician_account_num { get; set; }
        public string service_date { get; set; }
        public string patient_first_name { get; set; }
        public string patient_last_name { get; set; }
        public string patient_sex { get; set; }
        public string patient_health_num { get; set; }
        public string patient_dob { get; set; }
        public string lab_status { get; set; }
        public string doc_num { get; set; }
        public string doc_name { get; set; }
        public string doc_addr1 { get; set; }
        public string doc_addr2 { get; set; }
        public string doc_addr3 { get; set; }
        public string doc_postal { get; set; }
        public string doc_route { get; set; }
        public string comment1 { get; set; }
        public string comment2 { get; set; }
        public string patient_phone { get; set; }
        public string doc_phone { get; set; }
        public string collection_date { get; set; }
        public System.DateTime lastUpdateDate { get; set; }
    }
}
