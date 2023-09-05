using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Traversal_Web_App.CQRS.Commands.DestinationCommands;
using Traversal_Web_App.CQRS.Results.DestinationResults;

namespace Traversal_Web_App.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementListDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();

            CreateMap<GetDestinationByIDQueryResult, UpdateDestinationCommand>().ReverseMap();
        }
    }
}
