using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Models;
using PL.DTO;
using AutoMapper;

namespace PL.App_Start
{
    public class MapperConfig
    {
        public static IMapper mapper;

        public static void Initialize()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Test, TestDTO>()
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.Name));
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<Answear, AnswearDTO>();
            }).CreateMapper();
        }
    }
}