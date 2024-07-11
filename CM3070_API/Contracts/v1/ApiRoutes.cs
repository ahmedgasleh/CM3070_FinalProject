using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM3070_API.Contracts.v1
{
    public class ApiRoutes
    {
        public const string Root = "cm3070-portal";
        public const string Auth = "auth";
        public const string Version = "/v1";  //this value has to come from the configuration file
        public const string Base = Root + Version;

        public static class Posts
        {
            public const string GetDemographic = "/GetDemographic/{pid}";
            public const string PhysicianSearch = "/PhysicianSearch";
            public const string GetSchedule = "/GetSchedule";
            public const string GetScheduleByDate = "/GetScheduleByDate/{dte}";
            public const string GetScheduleEvent = "/GetScheduleEvent/{id}";

            //public const string GetPhysician = Base + "/Physician/{search}/&uuid={uuid}";

        }
    }
}
