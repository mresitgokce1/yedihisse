using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class KillingJoinAnimalProfile : Profile
    {
        public KillingJoinAnimalProfile()
        {
            CreateMap<KillingJoinAnimalAddDto, KillingJoinAnimal>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(x => true));

            CreateMap<KillingJoinAnimalUpdateDto, KillingJoinAnimal>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<KillingJoinAnimal, KillingJoinAnimalUpdateDto>();
            CreateMap<KillingJoinAnimal, KillingJoinAnimalDto>();
        }
    }
}
