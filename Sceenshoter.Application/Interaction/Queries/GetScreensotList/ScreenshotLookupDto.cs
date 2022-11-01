using AutoMapper;
using Sceenshoter.Domain.Models;
using Screenshoter.Application.Common.Mappings;

namespace Sceenshoter.Application.Interaction.Queries.GetScreensotList
{
    public class ScreenshotLookupDto : IMapWith<Screenshot>
    {
        public Guid Id { get; set; }
        public string? Base64 { get; set; }
        public DateTime? CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Screenshot, ScreenshotLookupDto>()
                .ForMember(screenDto => screenDto.Id,
                    opt => opt.MapFrom(screen => screen.Id))
                .ForMember(screenDto => screenDto.Base64,
                    opt => opt.MapFrom(screen => screen.Base64))
                .ForMember(screenDto => screenDto.CreateDate,
                    opt => opt.MapFrom(screen => screen.CreateDate));
                
        }
    }
}
