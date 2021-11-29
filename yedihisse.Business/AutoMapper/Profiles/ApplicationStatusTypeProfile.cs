using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.ApplicationStatusTypeDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class ApplicationStatusTypeProfile : Profile
    {
        public ApplicationStatusTypeProfile()
        {
            CreateMap<ApplicationStatusTypeAddDto, ApplicationStatusType>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<ApplicationStatusTypeUpdateDto, ApplicationStatusType>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<ApplicationStatusType, ApplicationStatusTypeUpdateDto>();
        }
    }
}
