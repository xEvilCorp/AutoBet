using AutoBet.Domain.Entities;
using AutoBet.Domain.ViewModels;
using AutoMapper;

namespace AutoBet.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CertificateInfo, CertificateViewModel>();
        }
    }
}
