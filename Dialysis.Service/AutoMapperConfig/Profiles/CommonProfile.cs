using AutoMapper;
using Dialysis.Domain.Models;
using Dialysis.Dto.Common;

namespace Dialysis.Service.AutoMapperConfig.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Shift, HospitalShiftDto>();
        }
    }
}
