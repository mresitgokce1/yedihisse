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
    public class UserJoinTypeProfile : Profile
    {
        public UserJoinTypeProfile()
        {
            CreateMap<UserJoinTypeAddDto, UserJoinType>()
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

            CreateMap<UserJoinTypeUpdateDto, UserJoinType>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<UserJoinType, UserJoinTypeUpdateDto>();
            CreateMap<UserJoinType, UserJoinTypeDto>();
        }
    }
}
