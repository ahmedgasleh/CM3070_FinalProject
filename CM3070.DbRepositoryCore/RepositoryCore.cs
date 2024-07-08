using CM3070.DbContextCore;
using CM3070.DbModelCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbRepositoryCore
{
    public class RepositoryCore : IRepositoryCore
    {
        private readonly CM3070DbContext _cm3070DbContext;

        private readonly IConfiguration _configuration;

        public RepositoryCore ( CM3070DbContext cm3070DbContext, IConfiguration configuration )
        {
            _cm3070DbContext = cm3070DbContext;
            _configuration = configuration;
        }
        public int DemographicCreatedOrUpdate ( Demographic demographic )
        {
            throw new NotImplementedException();
        }

        public async Task<Demographic> GetDemographic ( int Id )
        {
            Demographic result = new Demographic();

           

           return result = _cm3070DbContext.Demographic.Where(d => d.demographic_no == Id).FirstOrDefault();

                
        }

        public Facility GetFacility ( int Id )
        {
            throw new NotImplementedException();
        }

        public Provider GetProvider ( int Id )
        {
            throw new NotImplementedException();
        }

        public ScheduleDate GetSchedule ( int Id )
        {
            throw new NotImplementedException();
        }

        public List<PhysicianSearchParams> PhysicianSearch ( string id, string last_name )
        {
            List<PhysicianSearchParams> physicianSearchParams = new List<PhysicianSearchParams>();


            var result = _cm3070DbContext.Provider.Where(p => p.provider_no == id || p.last_name.Contains(last_name)).ToList();

            foreach (var p in result) {

                physicianSearchParams.Add(new PhysicianSearchParams { Id = p.provider_no, LastName = p.last_name });
            }

            return physicianSearchParams;
        }

        public List<SchaduleEvents> GetSchedule ()
        {
            List<SchaduleEvents> schaduleEvents  = new List<SchaduleEvents>();

            var scheduleDates = _cm3070DbContext.ScheduleDate.Where(s => s.id > 0).ToArray();

            foreach (var p in scheduleDates)
            {
                schaduleEvents.Add(new SchaduleEvents { title = p.reason + "|" + p.id.ToString() + "|" + p.provider_no, start = p.sdate.ToString("yyyy-MM-ddThh:mm:ss"), end = CalculateEnd(p.sdate, p.hour), 
                    color = GetEventColor(p.reason), url = "LoadEventDetail(" + p.id + ")" });
            }

            return schaduleEvents;
        }

        

        public List<SchaduleEvents> GetSchedule ( DateTime dateTime )
        {
            List<SchaduleEvents> schaduleEvents = new List<SchaduleEvents>();

            var scheduleDates = _cm3070DbContext.ScheduleDate.Where(s => s.sdate >=  dateTime).ToArray();

            foreach (var p in scheduleDates)
            {
                schaduleEvents.Add(new SchaduleEvents { title = p.reason + "|" + p.id.ToString() + "|" + p.provider_no, start = p.sdate.ToString("yyyy-MM-ddThh:mm:ss"), end = CalculateEnd(p.sdate, p.hour), color = GetEventColor(p.reason), url = "LoadEventDetail(" + p.id +")" });
            }

            return schaduleEvents;
        }

        private string GetEventColor ( string reason )
        {
            var eventColor = new Dictionary<string, string>() { { "#378006", "Visit" }, { "#86D1FC", "Follow" }, { "#EBE134", "Unknown" } };
            
            foreach(var item in eventColor)
            {
                if (reason.ToLower().Contains(item.Value.ToLower()))
                {
                    return item.Key;
                }
            }

            return "#EBE134";
        }

        private string CalculateEnd ( DateTime sdate, string hour )
        {
            string result = string.Empty;

            var ddate = sdate.AddMinutes(Convert.ToInt32(hour));

            result = ddate.ToString("yyyy-MM-ddThh:mm:ss");

            return result;
        }
    }
}
