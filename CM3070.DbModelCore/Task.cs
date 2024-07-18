using System;

namespace CM3070.DbModelCore
{
    public partial class Task
    {
        public int id { get; set; }
        public Nullable<int> demographic_no { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.DateTime> due_date { get; set; }
        public string? created_by { get; set; }
        public string? reason { get; set; }
        public int priority_id { get; set; }
        public string? notes { get; set; }
    }
}
