﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.PhoneNumberTypeDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class PhoneNumberTypeProfile : Profile
    {
        public PhoneNumberTypeProfile()
        {
            CreateMap<PhoneNumberTypeAddDto, PhoneNumberType>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<PhoneNumberTypeUpdateDto, PhoneNumberType>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<PhoneNumberType, PhoneNumberTypeUpdateDto>();
        }
    }
}