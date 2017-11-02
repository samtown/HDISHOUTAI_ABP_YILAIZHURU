using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dialysis.Domain;

namespace Dialysis.WebAdmin.Migrations
{
    [DbContext(typeof(DialysisContext))]
    [Migration("20170303073209_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Dialysis.Domain.Models.Administrator", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<long?>("HospitalId");

                    b.Property<bool>("IsSuperManager");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UserDesc")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("S_Administrator");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Alarm", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<DateTime?>("ConfirmedTime");

                    b.Property<decimal>("CurrentWeight");

                    b.Property<DateTime>("CurrentWeightTime");

                    b.Property<bool>("IsConfirmed");

                    b.Property<long>("PatientId");

                    b.Property<DateTime>("PostDialysisTime");

                    b.Property<decimal>("PostDialysisWeight");

                    b.Property<decimal>("WeightOverflow");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("P_Alarm");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.BloodPressure", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int?>("Breath");

                    b.Property<int>("DiastolicPressure");

                    b.Property<int?>("MeanArterialPressure");

                    b.Property<int>("MeasureMethod");

                    b.Property<DateTime>("MeasureTime");

                    b.Property<int>("MeasureType");

                    b.Property<long>("PatientId");

                    b.Property<int>("PulseRate");

                    b.Property<int>("SystolicPressure");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("P_BloodPressure");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.City", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("C_City");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Course", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("Logo")
                        .HasMaxLength(200);

                    b.Property<int>("SortId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("C_Course");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Dialysis", b =>
                {
                    b.Property<long>("Id");

                    b.Property<decimal?>("ActualUFV");

                    b.Property<string>("BedNo")
                        .HasMaxLength(8);

                    b.Property<decimal?>("ConfirmedUFV");

                    b.Property<DateTime>("DialysisDate");

                    b.Property<int?>("DialysisDuration");

                    b.Property<string>("DialysisWay")
                        .HasMaxLength(16);

                    b.Property<string>("Doctor")
                        .HasMaxLength(16);

                    b.Property<decimal?>("DryWeight");

                    b.Property<DateTime?>("EndTime");

                    b.Property<int?>("OffBreath");

                    b.Property<int?>("OffDiastolicPressure");

                    b.Property<string>("OffNurse")
                        .HasMaxLength(16);

                    b.Property<int?>("OffPulseRate");

                    b.Property<int?>("OffSystolicPressure");

                    b.Property<int?>("OnBreath");

                    b.Property<int?>("OnDiastolicPressure");

                    b.Property<string>("OnNurse")
                        .HasMaxLength(16);

                    b.Property<int?>("OnPulseRate");

                    b.Property<int?>("OnSystolicPressure");

                    b.Property<long>("PatientId");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<decimal?>("PlannedUFV");

                    b.Property<decimal?>("PostWeight");

                    b.Property<decimal?>("PreWeight");

                    b.Property<long>("ShiftId");

                    b.Property<DateTime?>("StartTime");

                    b.Property<string>("Summary")
                        .HasMaxLength(512);

                    b.Property<string>("TreatmentComment")
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("ShiftId");

                    b.ToTable("P_Dialysis");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Dictionary", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Logo")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ParentValue");

                    b.Property<int>("SortId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("S_Dictionary");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Doctor", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<DateTime>("Brithdate");

                    b.Property<int>("DeptId");

                    b.Property<string>("DoctorFace")
                        .HasMaxLength(200);

                    b.Property<long>("HospitalId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("SelfDesc")
                        .HasMaxLength(2000);

                    b.Property<int>("Sex");

                    b.Property<int>("TitleId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("D_Doctor");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.FoodNutrition", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<decimal>("Ca");

                    b.Property<decimal>("Carbohydrate");

                    b.Property<decimal>("DF");

                    b.Property<int>("Diabetes");

                    b.Property<int>("EdiblePart");

                    b.Property<decimal>("Energy");

                    b.Property<decimal>("Fat");

                    b.Property<decimal>("Fe");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("FoodType");

                    b.Property<int>("Hypertension");

                    b.Property<decimal>("K");

                    b.Property<string>("Logo")
                        .HasMaxLength(200);

                    b.Property<decimal>("Na");

                    b.Property<int>("Nephropathy");

                    b.Property<decimal>("P");

                    b.Property<decimal>("PRO");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<decimal>("Water");

                    b.HasKey("Id");

                    b.ToTable("C_FoodNutrition");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Hospital", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("CityId");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("C_Hospital");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Infomation", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("InfoCategory");

                    b.Property<string>("InfoContent")
                        .HasMaxLength(5000);

                    b.Property<string>("InfoLogo")
                        .HasMaxLength(200);

                    b.Property<string>("InfoTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsHomePageSlide");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("C_Infomation");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Message", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("AppType");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<bool>("IsRead");

                    b.Property<string>("OuterId")
                        .HasMaxLength(50);

                    b.Property<long>("ReceiveId");

                    b.Property<long>("SendId");

                    b.Property<string>("SendName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("SendTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("C_Message");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Patient", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<DateTime>("Brithdate");

                    b.Property<string>("CertNo")
                        .HasMaxLength(32);

                    b.Property<string>("CertType")
                        .HasMaxLength(8);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(20);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<DateTime?>("DateOfDeath");

                    b.Property<DateTime?>("DateOfEntry");

                    b.Property<long?>("DoctorId");

                    b.Property<DateTime?>("FirstDialysisDate");

                    b.Property<decimal>("Height");

                    b.Property<long>("HospitalId");

                    b.Property<string>("MedicalInsuranceType")
                        .HasMaxLength(8);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("PatientFace")
                        .HasMaxLength(200);

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PatientNo")
                        .HasMaxLength(10);

                    b.Property<string>("PatientPhone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("PinyinCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasMaxLength(2000);

                    b.Property<int>("Sex");

                    b.Property<string>("TherapyStatus")
                        .HasMaxLength(16);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserStatus");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HospitalId");

                    b.ToTable("P_Patient");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.PatientEducation", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CourseTypeId");

                    b.Property<long>("DoctorId");

                    b.Property<long>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("C_PatientEdu");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.PatientEducationDetail", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<long>("CourseId");

                    b.Property<long>("PatientEducationId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PatientEducationId");

                    b.ToTable("C_PatientEduDetail");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Province", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("C_Province");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Shift", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("DialysisShiftId");

                    b.Property<string>("EndTime")
                        .HasMaxLength(8);

                    b.Property<long>("HospitalId");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("ShiftType")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("StartTime")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("C_Shift");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Version", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("DownloadUrl")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("FileMD5")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdateLog")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("VersionCode");

                    b.Property<string>("VersionName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("VersionType");

                    b.HasKey("Id");

                    b.ToTable("S_Version");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Weight", b =>
                {
                    b.Property<long>("Id");

                    b.Property<int>("MeasureMethod");

                    b.Property<DateTime>("MeasureTime");

                    b.Property<int>("MeasureType");

                    b.Property<long>("PatientId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("P_Weight");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Administrator", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Hospital", "Hospital")
                        .WithMany("Administrators")
                        .HasForeignKey("HospitalId");
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Alarm", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Patient", "Patient")
                        .WithMany("Alarms")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.BloodPressure", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Patient", "Patient")
                        .WithMany("BloodPressures")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.City", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Dialysis", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dialysis.Domain.Models.Shift", "Shift")
                        .WithMany("Dialysiss")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Doctor", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Hospital", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.City", "City")
                        .WithMany("Hospitals")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Patient", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Dialysis.Domain.Models.Hospital", "Hospital")
                        .WithMany("Patients")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.PatientEducation", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dialysis.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.PatientEducationDetail", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dialysis.Domain.Models.PatientEducation", "PatientEducation")
                        .WithMany()
                        .HasForeignKey("PatientEducationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Shift", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dialysis.Domain.Models.Weight", b =>
                {
                    b.HasOne("Dialysis.Domain.Models.Patient", "Patient")
                        .WithMany("Weights")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
