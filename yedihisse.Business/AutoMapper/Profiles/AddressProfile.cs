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
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressAddDto, Address>()
                .ForMember(
                dest =>dest.CreatedDate,
                opt=>opt.MapFrom(x=>DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate, 
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<AddressUpdateDto, Address>()
                .ForMember(
                dest => dest.ModifiedDate, 
                opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Address, AddressUpdateDto>();
        }
    }
}
