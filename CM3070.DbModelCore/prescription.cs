using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class Prescription
    {
        public int script_no { get; set; }
        public string? provider_no {  get; set; }
        public int demographic_no { get; set; }
	    public DateTime date_prescribed { get; set; }
        public DateTime date_printed { get; set; }
        public DateTime dates_reprinted { get; set; }
	    public string? textView {  get; set; }
	    public string? rx_comments {  get; set; }
        public DateTime lastUpdateDate {  get; set; }
       
    }
}
