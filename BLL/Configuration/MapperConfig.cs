using Microsoft.AspNet.Identity.EntityFramework;
using AutoMapper;

namespace BLL.Configuration
{
    static class MapperConfig
    {
        public static IMapper Mapper;
        
        static MapperConfig()
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Entities.UserProfile, BLL.Models.User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ApplicationUser.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.ApplicationRole.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.ApplicationUser.PasswordHash))
                .ForMember(dest => dest.CompletedTests, opt => opt.MapFrom(src => src.CompletedTests));
                cfg.CreateMap<DAL.Entities.Subject, BLL.Models.Subject>();
                cfg.CreateMap<DAL.Entities.Test, BLL.Models.Test>();
                cfg.CreateMap<DAL.Entities.Question, BLL.Models.Question>();
                cfg.CreateMap<DAL.Entities.Answear, BLL.Models.Answear>();
                cfg.CreateMap<DAL.Entities.CompletedTest, BLL.Models.CompletedTest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Test.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Test.Description))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Test.Subject));
                cfg.CreateMap<DAL.Entities.CompletedQuestion, BLL.Models.CompletedQuestion>();
                cfg.CreateMap<BLL.Models.CompletedQuestion, DAL.Entities.CompletedQuestion>();
                cfg.CreateMap<BLL.Models.Test, DAL.Entities.Test>();
            });
            Mapper = configuration.CreateMapper();
        }
    }
}
