using CM3070.DbModelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3070.DbRepositoryCore
{
    public interface IRepositoryCore
    {
        public int DemographicCreatedOrUpdate(Demographic demographic);
        public Task<Demographic> GetDemographic ( int Id );

        public ScheduleDate GetSchedule ( int Id );

        public Provider GetProvider ( string Id );

        public Facility GetFacility ( int Id );

        public List<PhysicianSearchParams> PhysicianSearch ( string id, string last_name );

        public List<SchaduleEvents> GetSchedule ();

        public List<SchaduleEvents> GetSchedule (DateTime dateTime);

        public SchaduleEventDetail GetScheduleEvent ( int id );

        public List<Provider> GetProviders ();

        public int UpdateProvider(Provider provider );
    }
}
