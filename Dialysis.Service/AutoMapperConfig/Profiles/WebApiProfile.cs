using AutoMapper;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Domain.Models;
using Dialysis.Dto.WebApi;

namespace Dialysis.Service.AutoMapperConfig.Profiles
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            #region 数据同步
            CreateMap<AddShiftSync, Shift>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.Dialysiss, opt => { opt.Ignore(); })
                .ForMember(d => d.Hospital, opt => { opt.Ignore(); });

            CreateMap<AddDoctorSync, Doctor>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.Password, opt => { opt.Ignore(); })
                .ForMember(d => d.UserType, opt => { opt.MapFrom(c => (int)UserTypeEnum.Doctor); })
                .ForMember(d => d.DoctorFace, opt => { opt.Ignore(); })
                .ForMember(d => d.Brithdate, opt => { opt.Ignore(); })
                .ForMember(d => d.DeptId, opt => { opt.MapFrom(c => (int)DeptEnum.Nephrology); })
                .ForMember(d => d.TitleId, opt => { opt.MapFrom(c => (int)TitleEnum.ResidentPhysician); })
                .ForMember(d => d.SelfDesc, opt => { opt.Ignore(); })
                .ForMember(d => d.IsDelete, opt => { opt.MapFrom(c => false); })
                .ForMember(d => d.AddTime, opt => { opt.Ignore(); })
                .ForMember(d => d.UpdateTime, opt => { opt.Ignore(); })
                .ForMember(d => d.Hospital, opt => { opt.Ignore(); });

            CreateMap<AddPatientSync, Patient>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientFace, opt => { opt.Ignore(); })
                .ForMember(d => d.UserStatus, opt => { opt.Ignore(); })
                .ForMember(d => d.CupMAC, opt => { opt.Ignore(); })
                .ForMember(d => d.AddTime, opt => { opt.Ignore(); })
                .ForMember(d => d.UpdateTime, opt => { opt.Ignore(); })
                .ForMember(d => d.Hospital, opt => { opt.Ignore(); })
                .ForMember(d => d.Doctor, opt => { opt.Ignore(); })
                .ForMember(d => d.Alarms, opt => { opt.Ignore(); })
                .ForMember(d => d.BloodPressures, opt => { opt.Ignore(); })
                .ForMember(d => d.Weights, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientContacts, opt => { opt.Ignore(); });

            CreateMap<AddPatientContactSync, PatientContact>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientId, opt => { opt.Ignore(); })
                .ForMember(d => d.Password, opt => { opt.Ignore(); })
                .ForMember(d => d.AddTime, opt => { opt.Ignore(); })
                .ForMember(d => d.UpdateTime, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); });

            CreateMap<AddDialysisOnSync, Domain.Models.Dialysis>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.ShiftId, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientId, opt => { opt.Ignore(); })
                .ForMember(d => d.OffSystolicPressure, opt => { opt.Ignore(); })
                .ForMember(d => d.OffDiastolicPressure, opt => { opt.Ignore(); })
                .ForMember(d => d.OffPulseRate, opt => { opt.Ignore(); })
                .ForMember(d => d.OffBreath, opt => { opt.Ignore(); })
                .ForMember(d => d.PostWeight, opt => { opt.Ignore(); })
                .ForMember(d => d.ActualUFV, opt => { opt.Ignore(); })
                .ForMember(d => d.EndTime, opt => { opt.Ignore(); })
                .ForMember(d => d.OffNurse, opt => { opt.Ignore(); })
                .ForMember(d => d.Summary, opt => { opt.Ignore(); })
                .ForMember(d => d.Shift, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); });

            CreateMap<AddDialysisSync, Domain.Models.Dialysis>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.ShiftId, opt => { opt.Ignore(); })
                .ForMember(d => d.Shift, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientId, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); });

            CreateMap<AddBloodPressureSync, BloodPressure>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientId, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); });

            CreateMap<AddWeightSync, Weight>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.PatientId, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); });
            #endregion

            CreateMap<Doctor, DictDto>();

            CreateMap<Course, CourseDto>();

            CreateMap<Infomation, InfomationDto>();

            CreateMap<Message, MessageDto>();

            CreateMap<Dictionary, DictionaryDto>();

            CreateMap<FoodNutrition, FoodNutritionDto>();

            CreateMap<Weight, WeightDto>()
                .ForMember(d => d.MeasureTime, opt => opt.MapFrom(c => c.MeasureTime.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(d => d.MeasureType, opt => opt.MapFrom(c => EnumHelper.GetDescription((MeasureTypeEnum)c.MeasureType)));

            CreateMap<BloodPressure, BloodPressureDto>()
                .ForMember(d => d.MeasureTime, opt => opt.MapFrom(c => c.MeasureTime.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(d => d.MeasureType, opt => opt.MapFrom(c => EnumHelper.GetDescription((MeasureTypeEnum)c.MeasureType)));

            CreateMap<BloodSugar, BloodSugarDto>()
                .ForMember(d => d.AddTime, opt => opt.MapFrom(c => c.AddTime.ToString("yyyy-MM-dd HH:mm:ss")));

            CreateMap<Alarm, AlarmDto>()
                .ForMember(d => d.ColourType, opt => opt.MapFrom(c => Utility.CalculateColour(c.WeightOverflow, c.PostDialysisWeight)))
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.Patient.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.Patient.PatientFace)))
                .ForMember(d => d.DoctorName, opt => opt.MapFrom(c => c.Patient.Doctor.Name))
                .ForMember(d => d.PatientName, opt => opt.MapFrom(c => c.Patient.PatientName));

            CreateMap<Patient, PatientBaseDto>()
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.PatientFace)));

            CreateMap<Patient, PatientDto>()
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.PatientFace)))
                .ForMember(d => d.HasWeightData, opt => { opt.Ignore(); })
                .ForMember(d => d.HasBloodPressureData, opt => { opt.Ignore(); })
                .ForMember(d => d.HasBloodSugarData, opt => { opt.Ignore(); });

            CreateMap<Doctor, DoctorLoginOutput>()
                .ForMember(d => d.Dept, opt => { opt.MapFrom(s => EnumHelper.GetDescription((DeptEnum)s.DeptId)); })
                .ForMember(d => d.HospitalName, opt => { opt.MapFrom(s => s.Hospital.HospitalName); })
                .ForMember(d => d.Title, opt => { opt.MapFrom(s => EnumHelper.GetDescription((TitleEnum)s.TitleId)); })
                .ForMember(d => d.DoctorFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.DoctorFace) ? string.Empty : (CommConstant.OssUrl + c.DoctorFace)))
                .ForMember(d => d.PatientCount, opt => { opt.Ignore(); });

            CreateMap<AddBloodPressureInput, BloodPressure>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.DialysisBloodPressureId, opt => { opt.Ignore(); })
                .ForMember(d => d.MeasureType, opt => { opt.Ignore(); })
                .ForMember(d => d.MeasureMethod, opt => { opt.Ignore(); })
                .ForMember(d => d.MeanArterialPressure, opt => { opt.Ignore(); })
                .ForMember(d => d.Breath, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); });

            CreateMap<AddWeightInput, Weight>()
                .ForMember(d => d.Id, opt => { opt.Ignore(); })
                .ForMember(d => d.DialysisWeightId, opt => { opt.Ignore(); })
                .ForMember(d => d.MeasureMethod, opt => { opt.Ignore(); })
                .ForMember(d => d.Patient, opt => { opt.Ignore(); })
                .ForMember(d => d.MeasureTime, opt => { opt.Ignore(); });

            CreateMap<PatientContact, PatientLoginOutput>()
                .ForMember(d => d.Id, opt => { opt.MapFrom(s => s.Patient.Id); })
                .ForMember(d => d.PatientName, opt => { opt.MapFrom(s => s.Patient.PatientName); })
                .ForMember(d => d.ContactPhone, opt => { opt.MapFrom(s => s.MobilePhone); })
                .ForMember(d => d.Sex, opt => { opt.MapFrom(s => s.Patient.Sex); })
                .ForMember(d => d.TherapyStatus, opt => { opt.MapFrom(s => s.Patient.TherapyStatus); })
                .ForMember(d => d.Weight, opt => { opt.MapFrom(s => s.Patient.Weight); })
                .ForMember(d => d.Height, opt => { opt.MapFrom(s => s.Patient.Height); })
                .ForMember(d => d.UserStatus, opt => { opt.MapFrom(s => s.Patient.UserStatus); })
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.Patient.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.Patient.PatientFace)))
                .ForMember(d => d.Brithdate, opt => { opt.MapFrom(s => s.Patient.Brithdate); })
                .ForMember(d => d.Age, opt => opt.MapFrom(c => Utility.CalculateAge(c.Patient.Brithdate)))
                .ForMember(d => d.Remark, opt => { opt.MapFrom(s => s.Patient.Remark); })
                .ForMember(d => d.CupMAC, opt => { opt.MapFrom(s => s.Patient.CupMAC); })
                .ForMember(d => d.HospitalName, opt => { opt.MapFrom(s => s.Patient.Hospital.HospitalName); });

            CreateMap<Domain.Models.Dialysis, DialysisOnOutput>()
                .ForMember(d => d.StartTime, opt => { opt.MapFrom(s => s.StartTime.GetValueOrDefault().ToString(CommConstant.TimeFormatString)); })
                .ForMember(d => d.PlannedEndTime, opt =>
                {
                    opt.MapFrom(s => s.StartTime.GetValueOrDefault().AddMinutes(s.DialysisDuration.GetValueOrDefault()).ToString(CommConstant.TimeFormatString));
                });

            CreateMap<Domain.Models.Dialysis, DialysisOffOutput>();

            CreateMap<Domain.Models.Dialysis, DialysisListOutput>()
                .ForMember(d => d.DialysisDate, opt => { opt.MapFrom(s => s.DialysisDate.ToString(CommConstant.ShortDateFormatString)); });

            CreateMap<Domain.Models.Dialysis, DialysisDetailOutput>()
                .ForMember(d => d.StartTime, opt => { opt.MapFrom(s => s.StartTime.GetValueOrDefault().ToString(CommConstant.TimeFormatString)); })
                .ForMember(d => d.EndTime, opt => { opt.MapFrom(s => s.EndTime.GetValueOrDefault().ToString(CommConstant.TimeFormatString)); });
        }
    }
}
