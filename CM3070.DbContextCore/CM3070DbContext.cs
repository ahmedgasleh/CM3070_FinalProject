using Azure.Identity;
using CM3070.DbModelCore;
using Microsoft.EntityFrameworkCore;

namespace CM3070.DbContextCore
{
    public partial class CM3070DbContext : DbContext
    {
        public CM3070DbContext () { }

        public CM3070DbContext ( DbContextOptions<CM3070DbContext> options )
            : base ( options )
        {
        }
        public virtual DbSet<Demographic> Demographic { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<PatientId> PatientId { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderFacility> ProviderFacility { get; set; }
        public virtual DbSet<ScheduleDate> ScheduleDate { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<LabPatientPhysicianInfo> LabPatientPhysicianInfo { get; set; }
        public virtual DbSet<LabRequestReportLink> LabRequestReportLink { get; set; }
        public virtual DbSet<LabTestResults> LabTestResult { get; set; }
        public virtual DbSet<Tickler> Tickler { get; set; }
        public virtual DbSet<Tickler_Category> Tickler_Categories { get; set; }
        public virtual DbSet<DbModelCore.Task> Tasks { get; set; }

        public virtual DbSet<Mail> Mail { get; set; }   



        //SP calls

        public virtual DbSet<SchaduleEventDetail> SchaduleEventDetails { get; set; }
        public virtual DbSet<DemographicUpdate> DemographicUpdates { get; set; }

        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {

            modelBuilder.Entity<ScheduleDate>(entity =>
            {
                entity.HasKey(e => e.id);

            });
            modelBuilder.Entity<Demographic>(entity =>
            {
                entity.HasKey(e => e.demographic_no);

            });
            modelBuilder.Entity<PatientId>(entity =>
            {
                entity.HasKey(e => e.patient_id);

            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.provider_no);

            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<ProviderFacility>(entity =>
            {
                entity.HasKey(e => e.facility_id);

            });

           

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.document_no);

            });

            modelBuilder.Entity<LabPatientPhysicianInfo>(entity =>
            {
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<LabRequestReportLink>(entity =>
            {
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<LabTestResults>(entity =>
            {
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<Tickler>(entity =>
            {
                entity.HasKey(e => e.tickler_no);

            });

            modelBuilder.Entity<Tickler_Category>(entity =>
            {
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<DbModelCore.Task>(entity =>
            {
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.HasKey(e => e.id);

            });


        }
    }

    

    
}
