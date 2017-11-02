using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Admin;
using Dialysis.Common;
using Dialysis.Common.Enum;
using Dialysis.Dto.WebApi;
using System.Linq;

namespace Dialysis.Service.AutoMapperConfig.Profiles
{
    public class WebAdminProfile : Profile
    {
        public WebAdminProfile()
        {
            CreateMap<Patient, PatientViewDto>()
                .ForMember(d => d.Brithdate, opt => opt.MapFrom(c => c.Brithdate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.DoctorName, opt => opt.MapFrom(c => c.Doctor.Name))
                .ForMember(d => d.HospitalName, opt => opt.MapFrom(c => c.Hospital.HospitalName))
                .ForMember(d => d.UserStatusCss, opt => opt.MapFrom(c => Utility.GetUserStatusCss(c.UserStatus)))
                .ForMember(d => d.UserStatus, opt => opt.MapFrom(c => EnumHelper.GetDescription((UserStatusEnum)c.UserStatus)))
                .ForMember(d => d.Sex, opt => opt.MapFrom(c => EnumHelper.GetDescription((SexEnum)c.Sex)));

            CreateMap<Patient, PatientDetailViewDto>()
                .ForMember(d => d.Brithdate, opt => opt.MapFrom(c => c.Brithdate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.DateOfDeath, opt => opt.MapFrom(c => c.DateOfDeath.HasValue ? c.DateOfDeath.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(d => d.DateOfEntry, opt => opt.MapFrom(c => c.DateOfEntry.HasValue ? c.DateOfEntry.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(d => d.FirstDialysisDate, opt => opt.MapFrom(c => c.FirstDialysisDate.HasValue ? c.FirstDialysisDate.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.PatientFace)))
                .ForMember(d => d.DoctorName, opt => opt.MapFrom(c => c.Doctor.Name))
                .ForMember(d => d.HospitalName, opt => opt.MapFrom(c => c.Hospital.HospitalName))
                .ForMember(d => d.UserStatusCss, opt => { opt.Ignore(); })
                .ForMember(d => d.ContactContent, opt => { opt.Ignore(); })
                .ForMember(d => d.UserStatus, opt => opt.MapFrom(c => EnumHelper.GetDescription((UserStatusEnum)c.UserStatus)))
                .ForMember(d => d.Sex, opt => opt.MapFrom(c => EnumHelper.GetDescription((SexEnum)c.Sex)));

            CreateMap<Doctor, DoctorViewDto>()
                .ForMember(d => d.Brithdate, opt => opt.MapFrom(c => c.Brithdate.HasValue ? c.Brithdate.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(d => d.DeptName, opt => opt.MapFrom(c => EnumHelper.GetDescription((DeptEnum)c.DeptId)))
                .ForMember(d => d.HospitalName, opt => opt.MapFrom(c => c.Hospital.HospitalName))
                .ForMember(d => d.DoctorFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.DoctorFace) ? string.Empty : (CommConstant.OssUrl + c.DoctorFace)))
                .ForMember(d => d.Sex, opt => opt.MapFrom(c => EnumHelper.GetDescription((SexEnum)c.Sex)))
                .ForMember(d => d.TitleName, opt => opt.MapFrom(c => EnumHelper.GetDescription((TitleEnum)c.TitleId)))
                .ForMember(d => d.UserType, opt => opt.MapFrom(c => EnumHelper.GetDescription((UserTypeEnum)c.UserType)));

            CreateMap<Weight, AdminWeightDto>()
                .ForMember(d => d.MeasureTime, opt => opt.MapFrom(c => c.MeasureTime.ToString("MM-dd HH:mm").TrimStart('0')))
                .ForMember(d => d.MeasureType, opt => opt.MapFrom(c => EnumHelper.GetDescription((MeasureTypeEnum)c.MeasureType)));

            CreateMap<BloodPressure, AdminBloodPressureDto>()
                .ForMember(d => d.MeasureTime, opt => opt.MapFrom(c => c.MeasureTime.ToString("MM-dd HH:mm").TrimStart('0')))
                .ForMember(d => d.MeasureType, opt => opt.MapFrom(c => EnumHelper.GetDescription((MeasureTypeEnum)c.MeasureType)));

            CreateMap<Province, AdminProvinceDto>();

            CreateMap<City, AdminCityDto>();

            CreateMap<Hospital, AdminHospitalDto>()
                .ForMember(d => d.ProvinceId, opt => opt.MapFrom(c => c.City.ProvinceId));

            CreateMap<Hospital, HospitalViewDto>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(c => c.City.CityName))
                .ForMember(d => d.ProvinceName, opt => opt.MapFrom(c => c.City.Province.ProvinceName));

            CreateMap<Hospital, DictDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.HospitalName));

            CreateMap<Administrator, AdministratorDto>();

            CreateMap<Dictionary, CourseCategoryViewDto>();

            CreateMap<Dictionary, AdminCourseCategoryDto>();

            CreateMap<Course, AdminCourseDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(c => c.Type));

            CreateMap<Dictionary, DictDto>();

            CreateMap<Dialysis.Domain.Models.Dialysis, AdminDialysisDto>()
                .ForMember(d => d.DialysisDate, opt => opt.MapFrom(c => c.DialysisDate.ToString(CommConstant.ShortDateFormatString)))
                .ForMember(d => d.DialysisDuration, opt => opt.MapFrom(c => c.DialysisDuration.HasValue ? c.DialysisDuration.Value : 0))
                .ForMember(d => d.EndTime, opt => opt.MapFrom(c => c.EndTime.HasValue ? c.EndTime.Value.ToString(CommConstant.TimeFormatString) : string.Empty))
                .ForMember(d => d.StartTime, opt => opt.MapFrom(c => c.StartTime.HasValue ? c.StartTime.Value.ToString(CommConstant.TimeFormatString) : string.Empty))
                .ForMember(d => d.ShiftName, opt => opt.MapFrom(c => c.Shift.ShiftName));

            CreateMap<Doctor, AdminDoctorDto>();

            CreateMap<Patient, AdminPatientDto>()
                .ForMember(d => d.Phone, opt => opt.MapFrom(c => c.PatientContacts.FirstOrDefault() == null ? string.Empty : c.PatientContacts.FirstOrDefault().MobilePhone));

            CreateMap<Administrator, AdminLoginUserInfo>();

            CreateMap<Doctor, DictDto>();

            CreateMap<Water, AdminWaterDto>()
                .ForMember(d => d.DrinkTime, opt => opt.MapFrom(c => c.DrinkTime.ToString("MM-dd HH:mm").TrimStart('0')));

            CreateMap<BloodSugar, AdminBloodSugarDto>()
                .ForMember(d => d.AddTime, opt => opt.MapFrom(c => c.AddTime.ToString("MM-dd HH:mm").TrimStart('0')));

            CreateMap<HandRing, AdminHandRingDto>()
                .ForMember(d => d.Date, opt => opt.MapFrom(c => c.Date.ToString("yyyy-MM-dd")));
        }
    }
}
