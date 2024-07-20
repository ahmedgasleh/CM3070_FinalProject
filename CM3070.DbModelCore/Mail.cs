using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbModelCore
{
    public partial class  Mail
    {

         public int id {  get; set; }
         public int provider_no {  get; set; }
	     public DateTime received_date {  get; set; }	
	     public int priority_id { get; set; }   
	     public string? message { get; set; }
	     public string? attachment {  get; set; }
    }
}
