using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C_Course",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(maxLength: 5000, nullable: false),
                    Logo = table.Column<string>(maxLength: 200, nullable: true),
                    SortId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_Dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Logo = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentValue = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C_FoodNutrition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Ca = table.Column<decimal>(nullable: false),
                    Carbohydrate = table.Column<decimal>(nullable: false),
                    DF = table.Column<decimal>(nullable: false),
                    Diabetes = table.Column<int>(nullable: false),
                    EdiblePart = table.Column<int>(nullable: false),
                    Energy = table.Column<decimal>(nullable: false),
                    Fat = table.Column<decimal>(nullable: false),
                    Fe = table.Column<decimal>(nullable: false),
                    FoodName = table.Column<string>(maxLength: 50, nullable: false),
                    FoodType = table.Column<int>(nullable: false),
                    Hypertension = table.Column<int>(nullable: false),
                    K = table.Column<decimal>(nullable: false),
                    Logo = table.Column<string>(maxLength: 200, nullable: true),
                    Na = table.Column<decimal>(nullable: false),
                    Nephropathy = table.Column<int>(nullable: false),
                    P = table.Column<decimal>(nullable: false),
                    PRO = table.Column<decimal>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Water = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_FoodNutrition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C_Infomation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    InfoCategory = table.Column<int>(nullable: false),
                    InfoContent = table.Column<string>(maxLength: 5000, nullable: true),
                    InfoLogo = table.Column<string>(maxLength: 200, nullable: true),
                    InfoTitle = table.Column<string>(maxLength: 200, nullable: false),
                    IsHomePageSlide = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Infomation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C_Message",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AppType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 5000, nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    OuterId = table.Column<string>(maxLength: 60, nullable: true),
                    ReceiveId = table.Column<long>(nullable: false),
                    SendId = table.Column<long>(nullable: false),
                    SendName = table.Column<string>(maxLength: 50, nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C_Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProvinceName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_Version",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    DownloadUrl = table.Column<string>(maxLength: 200, nullable: false),
                    FileMD5 = table.Column<string>(maxLength: 50, nullable: false),
                    UpdateLog = table.Column<string>(maxLength: 500, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    VersionCode = table.Column<int>(nullable: false),
                    VersionName = table.Column<string>(maxLength: 20, nullable: false),
                    VersionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Version", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "C_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(maxLength: 20, nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_C_City_C_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "C_Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "C_Hospital",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    HospitalName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Hospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_C_Hospital_C_City_CityId",
                        column: x => x.CityId,
                        principalTable: "C_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "S_Administrator",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    HospitalId = table.Column<long>(nullable: true),
                    IsSuperManager = table.Column<bool>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserDesc = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_S_Administrator_C_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "C_Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "D_Doctor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Brithdate = table.Column<DateTime>(nullable: false),
                    DeptId = table.Column<int>(nullable: false),
                    DoctorFace = table.Column<string>(maxLength: 200, nullable: true),
                    HospitalId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    Phone = table.Column<string>(maxLength: 11, nullable: false),
                    SelfDesc = table.Column<string>(maxLength: 2000, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_D_Doctor_C_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "C_Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "C_Shift",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    DialysisShiftId = table.Column<int>(nullable: false),
                    EndTime = table.Column<string>(maxLength: 8, nullable: true),
                    HospitalId = table.Column<long>(nullable: false),
                    ShiftName = table.Column<string>(maxLength: 8, nullable: false),
                    ShiftType = table.Column<string>(maxLength: 8, nullable: false),
                    StartTime = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_C_Shift_C_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "C_Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P_Patient",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Brithdate = table.Column<DateTime>(nullable: false),
                    CertNo = table.Column<string>(maxLength: 32, nullable: true),
                    CertType = table.Column<string>(maxLength: 8, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 20, nullable: true),
                    ContactPhone = table.Column<string>(maxLength: 16, nullable: false),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    DateOfEntry = table.Column<DateTime>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    FirstDialysisDate = table.Column<DateTime>(nullable: true),
                    Height = table.Column<decimal>(nullable: false),
                    HospitalId = table.Column<long>(nullable: false),
                    MedicalInsuranceType = table.Column<string>(maxLength: 8, nullable: true),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    PatientFace = table.Column<string>(maxLength: 200, nullable: true),
                    PatientName = table.Column<string>(maxLength: 20, nullable: false),
                    PatientNo = table.Column<string>(maxLength: 10, nullable: true),
                    PatientPhone = table.Column<string>(maxLength: 11, nullable: false),
                    PinyinCode = table.Column<string>(maxLength: 20, nullable: false),
                    Remark = table.Column<string>(maxLength: 2000, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    TherapyStatus = table.Column<string>(maxLength: 16, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserStatus = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Patient_D_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "D_Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_P_Patient_C_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "C_Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P_Alarm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    ConfirmedTime = table.Column<DateTime>(nullable: true),
                    CurrentWeight = table.Column<decimal>(nullable: false),
                    CurrentWeightTime = table.Column<DateTime>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    PostDialysisTime = table.Column<DateTime>(nullable: false),
                    PostDialysisWeight = table.Column<decimal>(nullable: false),
                    WeightOverflow = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Alarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Alarm_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P_BloodPressure",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Breath = table.Column<int>(nullable: true),
                    DiastolicPressure = table.Column<int>(nullable: false),
                    MeanArterialPressure = table.Column<int>(nullable: true),
                    MeasureMethod = table.Column<int>(nullable: false),
                    MeasureTime = table.Column<DateTime>(nullable: false),
                    MeasureType = table.Column<int>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    PulseRate = table.Column<int>(nullable: false),
                    SystolicPressure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_BloodPressure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_BloodPressure_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P_Dialysis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    ActualUFV = table.Column<decimal>(nullable: true),
                    BedNo = table.Column<string>(maxLength: 8, nullable: true),
                    ConfirmedUFV = table.Column<decimal>(nullable: true),
                    DialysisDate = table.Column<DateTime>(nullable: false),
                    DialysisDuration = table.Column<int>(nullable: true),
                    DialysisWay = table.Column<string>(maxLength: 16, nullable: true),
                    Doctor = table.Column<string>(maxLength: 16, nullable: true),
                    DryWeight = table.Column<decimal>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    OffBreath = table.Column<int>(nullable: true),
                    OffDiastolicPressure = table.Column<int>(nullable: true),
                    OffNurse = table.Column<string>(maxLength: 16, nullable: true),
                    OffPulseRate = table.Column<int>(nullable: true),
                    OffSystolicPressure = table.Column<int>(nullable: true),
                    OnBreath = table.Column<int>(nullable: true),
                    OnDiastolicPressure = table.Column<int>(nullable: true),
                    OnNurse = table.Column<string>(maxLength: 16, nullable: true),
                    OnPulseRate = table.Column<int>(nullable: true),
                    OnSystolicPressure = table.Column<int>(nullable: true),
                    PatientId = table.Column<long>(nullable: false),
                    PatientName = table.Column<string>(maxLength: 32, nullable: false),
                    PlannedUFV = table.Column<decimal>(nullable: true),
                    PostWeight = table.Column<decimal>(nullable: true),
                    PreWeight = table.Column<decimal>(nullable: true),
                    ShiftId = table.Column<long>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    Summary = table.Column<string>(maxLength: 512, nullable: true),
                    TreatmentComment = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Dialysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Dialysis_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_P_Dialysis_C_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "C_Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "C_PatientEdu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    BatchNumber = table.Column<string>(maxLength: 50, nullable: false),
                    CourseTypeId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<long>(nullable: false),
                    PatientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_PatientEdu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_C_PatientEdu_D_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "D_Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_C_PatientEdu_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P_Weight",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    MeasureMethod = table.Column<int>(nullable: false),
                    MeasureTime = table.Column<DateTime>(nullable: false),
                    MeasureType = table.Column<int>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Weight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Weight_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "C_PatientEduDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    PatientEducationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_PatientEduDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_C_PatientEduDetail_C_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "C_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_C_PatientEduDetail_C_PatientEdu_PatientEducationId",
                        column: x => x.PatientEducationId,
                        principalTable: "C_PatientEdu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_S_Administrator_HospitalId",
                table: "S_Administrator",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Alarm_PatientId",
                table: "P_Alarm",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_P_BloodPressure_PatientId",
                table: "P_BloodPressure",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_C_City_ProvinceId",
                table: "C_City",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Dialysis_PatientId",
                table: "P_Dialysis",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Dialysis_ShiftId",
                table: "P_Dialysis",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_D_Doctor_HospitalId",
                table: "D_Doctor",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_C_Hospital_CityId",
                table: "C_Hospital",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Patient_DoctorId",
                table: "P_Patient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Patient_HospitalId",
                table: "P_Patient",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_C_PatientEdu_DoctorId",
                table: "C_PatientEdu",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_C_PatientEdu_PatientId",
                table: "C_PatientEdu",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_C_PatientEduDetail_CourseId",
                table: "C_PatientEduDetail",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_C_PatientEduDetail_PatientEducationId",
                table: "C_PatientEduDetail",
                column: "PatientEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_C_Shift_HospitalId",
                table: "C_Shift",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Weight_PatientId",
                table: "P_Weight",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "S_Administrator");

            migrationBuilder.DropTable(
                name: "P_Alarm");

            migrationBuilder.DropTable(
                name: "P_BloodPressure");

            migrationBuilder.DropTable(
                name: "P_Dialysis");

            migrationBuilder.DropTable(
                name: "S_Dictionary");

            migrationBuilder.DropTable(
                name: "C_FoodNutrition");

            migrationBuilder.DropTable(
                name: "C_Infomation");

            migrationBuilder.DropTable(
                name: "C_Message");

            migrationBuilder.DropTable(
                name: "C_PatientEduDetail");

            migrationBuilder.DropTable(
                name: "S_Version");

            migrationBuilder.DropTable(
                name: "P_Weight");

            migrationBuilder.DropTable(
                name: "C_Shift");

            migrationBuilder.DropTable(
                name: "C_Course");

            migrationBuilder.DropTable(
                name: "C_PatientEdu");

            migrationBuilder.DropTable(
                name: "P_Patient");

            migrationBuilder.DropTable(
                name: "D_Doctor");

            migrationBuilder.DropTable(
                name: "C_Hospital");

            migrationBuilder.DropTable(
                name: "C_City");

            migrationBuilder.DropTable(
                name: "C_Province");
        }
    }
}
