﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.ApplicationStatusDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class ApplicationStatusProfile : Profile
    {
        public ApplicationStatusProfile()
        {
            CreateMap<ApplicationStatusAddDto, ApplicationStatus>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<ApplicationStatusUpdateDto, ApplicationStatus>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<ApplicationStatus, ApplicationStatusUpdateDto>();
        }
    }
}
