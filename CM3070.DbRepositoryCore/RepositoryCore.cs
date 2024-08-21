using CM3070.DbContextCore;
using CM3070.DbModelCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;


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
        
        public async Task<Demographic> GetDemographic ( string Id )
        {
            Demographic result = new Demographic();

           
          
           return result = _cm3070DbContext.Demographic.Where(d => d.hin == Id).FirstOrDefault();

                
        }

        public int DemographicCreatedOrUpdate ( Demographic demographic )
        {
            throw new NotImplementedException();
        }

        public Facility GetFacility ( int Id )
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

        
        public SchaduleEventDetail GetScheduleEvent ( int id )
        {
           
            try
            {
                SqlParameter [] sqlParameters =
                {
                    ExtensionMethods.SetSqlParameter("@id", false, id, SqlDbType.Int)
                };

                var rawSQL = "dbo.GetSchadule @id";

                var result = _cm3070DbContext.SchaduleEventDetails.FromSqlRaw(rawSQL, sqlParameters).AsEnumerable().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {

                return new SchaduleEventDetail();
            } 


        }

        public Provider GetProvider ( string Id )
        {
            var result = _cm3070DbContext.Provider.Where(p => p.provider_no == Id).FirstOrDefault();

            return result;
        }


        public List<Provider> GetProviders ()
        {
            var result = _cm3070DbContext.Provider.ToList();

            return result;
        }

        public List<DbModelCore.Task> GetTask (int id)
        {

            var result = _cm3070DbContext.Tasks.Where(t => t.id >= id).ToList();

            return result;
        }

        public List<Document> GetHomeDocuments ( int id )
        {
            try
            {
                var result = _cm3070DbContext.Document.Where(t => t.document_no >= id).ToList();

                 return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public List<Mail> GetMail( int id )
        {
            if(id == 0)
            {
                var result = _cm3070DbContext.Mail.Where(t => t.priority_id >= id).ToList();

                return result;
            }
            else
            {
                var result = _cm3070DbContext.Mail.Where(t => t.priority_id == id).ToList();

                return result;
            }
            
        }

        public List<prescription> GetPrescription ( int id )
        {
            try
            {
                if (id == 0)
                {
                    var result = _cm3070DbContext.Prescriptions.Where(t => t.script_no >= id).ToList();

                    return result;
                }
                else
                {
                    var result = _cm3070DbContext.Prescriptions.Where(t => t.script_no == id).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }


        public int CreateScheduleEvent ( ScheduleDate detail )
        {
            

            try
            {
                SqlParameter [] dataParameters =
                {
                     ExtensionMethods.SetSqlParameter("@id",false,detail.id, SqlDbType.Int),
                     ExtensionMethods.SetSqlParameter("@sdate",false,detail.sdate, SqlDbType.DateTime),
                     ExtensionMethods.SetSqlParameter("@provider_no",false,detail.provider_no, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@available",false,detail.available, SqlDbType.Char),
                     ExtensionMethods.SetSqlParameter("@priority",false,detail.priority, SqlDbType.Char),
                     ExtensionMethods.SetSqlParameter("@reason",false,detail.reason, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@hour",false,detail.hour, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@creator",false,detail.creator, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@status",false,detail.status, SqlDbType.Char),
                };

                var sqlRaw = "dbo.CreateSchaduleEvent @id, @sdate, @provider_no, @available, @priority, @reason, @hour, @creator, @status";

                var result = _cm3070DbContext.ScheduleDate.FromSqlRaw(sqlRaw, dataParameters).AsEnumerable().FirstOrDefault();

                return 1;

            }
            catch (Exception)
            {

                return 0;
            }

           
        }


        public int UpdateProvider ( Provider provider )
        {
            try
            {
                SqlParameter [] dataParameters = {
                    ExtensionMethods.SetSqlParameter("@provider_no",false,provider.provider_no, SqlDbType.Int),
                    ExtensionMethods.SetSqlParameter("@last_name",false,provider.last_name, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@first_name",false,provider.first_name, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@provider_type",false,provider.provider_type, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@supervisor",false,provider.supervisor, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@specialty",false,provider.supervisor, SqlDbType.NVarChar),

                    ExtensionMethods.SetSqlParameter("@team",false,provider.status, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@sex",false,provider.sex, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@dob",false,provider.dob, SqlDbType.Date),
                    ExtensionMethods.SetSqlParameter("@address",false,provider.address, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@phone",false,provider.phone, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@work_phone",false,provider.work_phone, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@ohip_no",false,provider.ohip_no, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@rma_no",false,provider.rma_no, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@billing_no",false,provider.billing_no, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@hso_no",false,provider.hso_no, SqlDbType.NVarChar),

                    ExtensionMethods.SetSqlParameter("@status",false,provider.status, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@comments",false,provider.comments, SqlDbType.Text),
                    ExtensionMethods.SetSqlParameter("@provider_activity",false,provider.@provider_activity, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@practitionerNo",false,provider.practitionerNo, SqlDbType.NVarChar),
                    ExtensionMethods.SetSqlParameter("@init",false,provider.init, SqlDbType.NVarChar),

                     ExtensionMethods.SetSqlParameter("@job_title",false,provider.job_title, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@email",false,provider.email, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@title",false,provider.title, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@lastUpdateUser",false,provider.lastUpdateUser, SqlDbType.NVarChar),
                     ExtensionMethods.SetSqlParameter("@lastUpdateDate",false,provider.lastUpdateDate, SqlDbType.Date),
                     ExtensionMethods.SetSqlParameter("@signed_confidentiality",false,provider.signed_confidentiality, SqlDbType.Date),
                     ExtensionMethods.SetSqlParameter("@thirdPartyOnly",false,provider.thirdPartyOnly, SqlDbType.Bit),
                     ExtensionMethods.SetSqlParameter("@practitionerNoType",false,provider.@practitionerNoType, SqlDbType.NVarChar),
                };

                var sqlRaw = "dbo.UpdateProvider @provider_no,@last_name,@first_name,@provider_type,@supervisor,@specialty,@team,@sex,@dob,@address,@phone,@work_phone,@ohip_no,@rma_no," +
                    "@billing_no,@hso_no,@status,@comments,@provider_activity,@practitionerNo,@init,@job_title,@email,@title,@lastUpdateUser,@lastUpdateDate,@signed_confidentiality,@thirdPartyOnly,@practitionerNoType";

                var result = _cm3070DbContext.Provider.FromSqlRaw(sqlRaw, dataParameters).AsEnumerable().FirstOrDefault();
                
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public int UpdateDemographic ( DemographicUpdate demographic )
        {
            try
            {
                SqlParameter [] dataParameters = {
                  ExtensionMethods.SetSqlParameter("@demographic_no",false,demographic.demographic_no, SqlDbType.Int),
                  ExtensionMethods.SetSqlParameter("@patient_id",false,demographic.patient_id, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@title",false,demographic.title, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@last_name",false,demographic.last_name, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@first_name",false,demographic.first_name, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@sex",false,demographic.sex, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@address",false,demographic.address, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@province",false,demographic.province, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@city",false,demographic.city, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@postal",false,demographic.postal, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@phone",false,demographic.phone, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@phone2",false,demographic.phone2, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@ver",false,demographic.ver, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@email",false,demographic.email, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@hin",false,demographic.hin, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@year_of_birth",false,demographic.year_of_birth, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@month_of_birth",false,demographic.month_of_birth, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@date_of_birth",false,demographic.date_of_birth, SqlDbType.NVarChar),
                  ExtensionMethods.SetSqlParameter("@provider_no",false,demographic.provider_no, SqlDbType.NVarChar),
             };

                var rawSQL = "dbo.UpdateDemographic @patient_id,@title,@last_name,@first_name,@sex,@address,@province,@city,@postal,@phone, @phone2,@ver,@email,@hin,@year_of_birth,@month_of_birth,@date_of_birth,@provider_no";

                var result = _cm3070DbContext.DemographicUpdates.FromSqlRaw(rawSQL, dataParameters).AsEnumerable();

                return 1;
            
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

       
    }
}
