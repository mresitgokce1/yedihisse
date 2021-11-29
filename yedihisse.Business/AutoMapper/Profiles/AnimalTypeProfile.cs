using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.AnimalTypeDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class AnimalTypeProfile : Profile
    {
        public AnimalTypeProfile()
        {
            CreateMap<AnimalTypeAddDto, AnimalType>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<AnimalTypeUpdateDto, AnimalType>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<AnimalType, AnimalTypeUpdateDto>();
        }
    }
}
