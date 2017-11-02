using Dialysis.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dialysis.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class DialysisContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DialysisContext(DbContextOptions<DialysisContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Administrator> Administrator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Alarm> Alarm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<BloodPressure> BloodPressure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<City> City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Course> Course { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Models.Dialysis> Dialysis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Dictionary> Dictionary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Doctor> Doctor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<FoodNutrition> FoodNutrition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<HandRing> HandRing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Hospital> Hospital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Infomation> Infomation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Message> Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Patient> Patient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<PatientContact> PatientContact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<PatientEducation> PatientEducation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<PatientEducationDetail> PatientEducationDetail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Province> Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Shift> Shift { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Version> Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Weight> Weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Water> Water { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<BloodSugar> BloodSugar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().ToTable("S_Administrator");
            modelBuilder.Entity<Alarm>().ToTable("P_Alarm");
            modelBuilder.Entity<BloodPressure>().ToTable("P_BloodPressure");
            modelBuilder.Entity<City>().ToTable("C_City");
            modelBuilder.Entity<Course>().ToTable("C_Course");
            modelBuilder.Entity<Models.Dialysis>().ToTable("P_Dialysis");
            modelBuilder.Entity<Dictionary>().ToTable("S_Dictionary");
            modelBuilder.Entity<Doctor>().ToTable("D_Doctor");
            modelBuilder.Entity<FoodNutrition>().ToTable("C_FoodNutrition");
            modelBuilder.Entity<HandRing>().ToTable("P_HandRing");
            modelBuilder.Entity<Hospital>().ToTable("C_Hospital");
            modelBuilder.Entity<Infomation>().ToTable("C_Infomation");
            modelBuilder.Entity<Message>().ToTable("C_Message");
            modelBuilder.Entity<Patient>().ToTable("P_Patient");
            modelBuilder.Entity<PatientContact>().ToTable("P_Contact");
            modelBuilder.Entity<PatientEducation>().ToTable("C_PatientEdu");
            modelBuilder.Entity<PatientEducationDetail>().ToTable("C_PatientEduDetail");
            modelBuilder.Entity<Province>().ToTable("C_Province");
            modelBuilder.Entity<Shift>().ToTable("C_Shift");
            modelBuilder.Entity<Version>().ToTable("S_Version");
            modelBuilder.Entity<Weight>().ToTable("P_Weight");
            modelBuilder.Entity<Water>().ToTable("P_Water");
            modelBuilder.Entity<BloodSugar>().ToTable("P_BloodSugar");
        }
    }
}
