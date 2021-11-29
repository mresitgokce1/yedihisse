﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.CarMissionTypeDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class CarMissionTypeProfile : Profile
    {
        public CarMissionTypeProfile()
        {
            CreateMap<CarMissionTypeAddDto, CarMissionType>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<CarMissionTypeUpdateDto, CarMissionType>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<CarMissionType, CarMissionTypeUpdateDto>();
        }
    }
}
