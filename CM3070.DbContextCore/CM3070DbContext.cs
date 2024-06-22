using CM3070.DbModelCore;
using Microsoft.EntityFrameworkCore;

namespace CM3070.DbContextCore
{
    public partial class CM3070DbContext : DbContext
    {
        public CM3070DbContext ()
        {
        }

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

        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
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

            modelBuilder.Entity<ScheduleDate>(entity =>
            {
                entity.HasKey(e => e.id);

            });
        }
    }

    

    
}
