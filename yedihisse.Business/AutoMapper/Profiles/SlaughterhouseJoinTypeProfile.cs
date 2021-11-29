﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.SlaughterhouseJoinTypeDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class SlaughterhouseJoinTypeProfile : Profile
    {
        public SlaughterhouseJoinTypeProfile()
        {
            CreateMap<SlaughterhouseJoinTypeAddDto, SlaughterhouseJoinType>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<SlaughterhouseJoinTypeUpdateDto, SlaughterhouseJoinType>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<SlaughterhouseJoinType, SlaughterhouseJoinTypeUpdateDto>();
        }
    }
}
