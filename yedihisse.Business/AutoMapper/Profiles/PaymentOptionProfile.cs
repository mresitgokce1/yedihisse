using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using yedihisse.Entities.Concrete;
using yedihisse.Entities.Dtos.PaymentOptionDto;

namespace yedihisse.Business.AutoMapper.Profiles
{
    public class PaymentOptionProfile : Profile
    {
        public PaymentOptionProfile()
        {
            CreateMap<PaymentOptionAddDto, PaymentOption>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(
                    dest => dest.IsDeleted,
                    opt => opt.MapFrom(x => false));

            CreateMap<PaymentOptionUpdateDto, PaymentOption>()
                .ForMember(
                    dest => dest.ModifiedDate,
                    opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<PaymentOption, PaymentOptionUpdateDto>();
        }
    }
}
