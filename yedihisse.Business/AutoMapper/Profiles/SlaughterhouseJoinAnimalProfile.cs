using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.SlaughterhouseJoinAnimalDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class SlaughterhouseJoinAnimalProfile : Profile
    {
        public SlaughterhouseJoinAnimalProfile()
        {
            CreateMap<SlaughterhouseJoinAnimalAddDto, SlaughterhouseJoinAnimal>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<SlaughterhouseJoinAnimalUpdateDto, SlaughterhouseJoinAnimal>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<SlaughterhouseJoinAnimal, SlaughterhouseJoinAnimalUpdateDto>();
        }
    }
}
