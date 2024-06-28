

namespace CM3070.DbModelCore
{
    using System;
    using System.Collections.Generic;
    public partial class Document
    {
        public int document_no { get; set; }
        public string doctype { get; set; }
        public string docClass { get; set; }
        public string docSubClass { get; set; }
        public string docdesc { get; set; }
        public string docxml { get; set; }
        public string docfilename { get; set; }
        public string doccreator { get; set; }
        public string responsible { get; set; }
        public string source { get; set; }
        public string sourceFacility { get; set; }
        public Nullable<int> program_id { get; set; }
        public Nullable<System.DateTime> updatedatetime { get; set; }
        public string status { get; set; }
        public string contenttype { get; set; }
        public Nullable<System.DateTime> contentdatetime { get; set; }
        public int public1 { get; set; }
        public Nullable<System.DateTime> observationdate { get; set; }
        public string reviewer { get; set; }
        public Nullable<System.DateTime> reviewdatetime { get; set; }
        public Nullable<int> number_of_pages { get; set; }
        public Nullable<int> appointment_no { get; set; }
        public byte restrictToProgram { get; set; }
        public Nullable<bool> abnormal { get; set; }
    }
}
