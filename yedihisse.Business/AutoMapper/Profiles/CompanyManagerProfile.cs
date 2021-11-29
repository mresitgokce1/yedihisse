using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.CompanyManagerDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class CompanyManagerProfile : Profile
    {
        public CompanyManagerProfile()
        {
            CreateMap<CompanyManagerAddDto, CompanyManager>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<CompanyManagerUpdateDto, CompanyManager>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<CompanyManager, CompanyManagerUpdateDto>();
        }
    }
}
