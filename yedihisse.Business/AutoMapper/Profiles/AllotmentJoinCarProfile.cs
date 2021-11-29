using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.AllotmentJoinCarDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class AllotmentJoinCarProfile : Profile
    {
        public AllotmentJoinCarProfile()
        {
            CreateMap<AllotmentJoinCarAddDto, AllotmentJoinCar>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<AllotmentJoinCarUpdateDto, AllotmentJoinCar>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<AllotmentJoinCar, AllotmentJoinCarUpdateDto>();
        }
    }
}
