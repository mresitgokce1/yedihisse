﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.AllotmentDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class AllotmentProfile : Profile
    {
        public AllotmentProfile()
        {
            CreateMap<AllotmentAddDto, Allotment>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<AllotmentUpdateDto, Allotment>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Allotment, AllotmentUpdateDto>();
        }
    }
}