using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagment2.Models;

namespace UserManagment2.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public virtual DbSet<Diagnosis> Diagnoses { get; set; }

        public virtual DbSet<DiagnosisDrug> DiagnosisDrugs { get; set; }

        public virtual DbSet<DiagnosisTest> DiagnosisTests { get; set; }

        public virtual DbSet<Drug> Drugs { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<TestsXRay> TestsXRays { get; set; }

        public virtual DbSet<Visit> Visits { get; set; }

  //      protected override void OnModelCreating(ModelBuilder builder)
		//{
		//	base.OnModelCreating(builder);

		//	// Change table names
			
		//}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasNoKey();

                // Additional configuration for the entity if needed

                entity.ToTable("UserLogins");
            });
            
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasNoKey();

                // Additional configuration for the entity if needed

                entity.ToTable("UserRoles");
            }); 
            
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });

                // Additional configuration for the entity if needed

                entity.ToTable("UserTokens");
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("diagnosis");

                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
                entity.Property(e => e.Diagnosis1)
                    .HasMaxLength(4000)
                    .HasColumnName("diagnosis");
                entity.Property(e => e.DiagnosisDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("diagnosis_date");
                entity.Property(e => e.DiagnosisLocation)
                    .HasMaxLength(100)
                    .HasColumnName("diagnosis_location");
                entity.Property(e => e.DoctorDecision)
                    .HasMaxLength(300)
                    .HasColumnName("doctor_decision");
                entity.Property(e => e.Examiation)
                    .HasMaxLength(4000)
                    .HasColumnName("examiation");
                entity.Property(e => e.Tests)
                    .HasMaxLength(500)
                    .HasColumnName("tests");
                entity.Property(e => e.Drugs)
                    .HasMaxLength(500)
                    .HasColumnName("drugs");
                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.HasOne(d => d.Visit).WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.VisitId)
                    .HasConstraintName("FK_diagnosis_visits");
            });

            modelBuilder.Entity<DiagnosisDrug>(entity =>
            {
                entity.ToTable("diagnosis_drugs");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
                entity.Property(e => e.DrugId).HasColumnName("drug_id");

                entity.HasOne(d => d.Diagnosis).WithMany(p => p.DiagnosisDrugs)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK_diagnosisDrugs_diagnosis");

                entity.HasOne(d => d.DiagnosisNavigation).WithMany(p => p.DiagnosisDrugs)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK_diagnosisDrugs_drugs");
            });

            modelBuilder.Entity<DiagnosisTest>(entity =>
            {
                entity.ToTable("diagnosis_tests");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.HasOne(d => d.Diagnosis).WithMany(p => p.DiagnosisTests)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK_diagnosisTests_diagnosis");

                entity.HasOne(d => d.Test).WithMany(p => p.DiagnosisTests)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_diagnosisTests_tests_x-rays");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.ToTable("drugs");

                entity.Property(e => e.DrugId).HasColumnName("drug_id");
                entity.Property(e => e.Concentration)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("concentration");
                entity.Property(e => e.GenericName)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("generic_name");
                entity.Property(e => e.TreatmentId).HasColumnName("treatment_id");
                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId).HasName("PK_patient_1");

                entity.ToTable("patient");

                entity.HasIndex(e => e.PatientId, "UNQ_National_id").IsUnique();

                entity.HasIndex(e => e.Umn, "UNQ_Patient_UMN").IsUnique();

                entity.Property(e => e.PatientId).HasColumnName("patient_id");
                entity.Property(e => e.NationalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("national_id");
                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(100)
                    .HasColumnName("patient_address");
                entity.Property(e => e.PatientAge).HasColumnName("patient_age");
                entity.Property(e => e.PatientName)
                    .HasMaxLength(100)
                    .HasColumnName("patient_name");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
                entity.Property(e => e.Umn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("umn");
            });

            modelBuilder.Entity<TestsXRay>(entity =>
            {
                entity.HasKey(e => e.TestId);

                entity.ToTable("tests_x-rays");

                entity.Property(e => e.TestId).HasColumnName("test_id");
                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("category");
                entity.Property(e => e.TestName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("test_name");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("visits");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");
                entity.Property(e => e.CurrentLocation)
                    .HasMaxLength(100)
                    .HasColumnName("current_location");
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("entry_date");
                entity.Property(e => e.EntryPlace)
                    .HasMaxLength(50)
                    .HasColumnName("entry_place");
                entity.Property(e => e.PatientId).HasColumnName("patient_id");
                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .HasColumnName("payment_type");
                entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");
                entity.Property(e => e.Umn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("umn");

                entity.HasOne(d => d.Patient).WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_visits_patient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}