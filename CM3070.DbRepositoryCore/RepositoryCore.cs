using CM3070.DbContextCore;
using CM3070.DbModelCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

            //result.demographic_no = 1;
            //result.hin = "1234567897";
            //result.ver = "HC";
            //result.first_name = "Bram";
            //result.last_name = "Toron";
            //result.year_of_birth = "1977";
            //result.month_of_birth = "01";
            //result.date_of_birth = "13";
            //result.sex = "Male";
            //result.address = "1110 Finch";
            //result.city = "North York";
            //result.province = "ON";
            //result.postal = "L6R";
            //result.phone = "4165556666";
            //result.phone2 = "4165551111";
            //result.lastUpdateDate = DateTime.Now.AddDays(-100);





            //return result;

           
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

            //physicianSearchParams.Add(new PhysicianSearchParams { Id = "1001", LastName = "Moo (13 Huf Rd)" });
            //physicianSearchParams.Add(new PhysicianSearchParams { Id = "1002", LastName = "Klien (MakelJackson)" });
            //physicianSearchParams.Add(new PhysicianSearchParams { Id = "1003", LastName = "Kavin (19 MakelJackson)" });
            //physicianSearchParams.Add(new PhysicianSearchParams { Id = "1004", LastName = "Lady (13 HokeyRd)" });

            return physicianSearchParams;
        }
    }
}
