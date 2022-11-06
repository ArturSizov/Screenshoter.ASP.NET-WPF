using AutoMapper;
using Sceenshoter.Domain.Models;
using Screenshoter.ScreenshoterApplication.Common.Mappings;

namespace Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList
{
    public class ScreenshotLookupDto : IMapWith<Screenshot>
    {
        public string? Base64 { get; set; }
        public DateTime? CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Screenshot, ScreenshotLookupDto>()
                .ForMember(screenDto => screenDto.Base64,
                    opt => opt.MapFrom(screen => screen.Base64))
                .ForMember(screenDto => screenDto.CreateDate,
                    opt => opt.MapFrom(screen => screen.CreateDate));
                
        }
    }
}
