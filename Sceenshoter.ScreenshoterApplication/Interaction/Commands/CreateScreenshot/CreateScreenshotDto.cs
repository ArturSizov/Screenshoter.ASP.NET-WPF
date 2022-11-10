using AutoMapper;
using Screenshoter.ScreenshoterApplication.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Screenshoter.ScreenshoterApplication.Interaction.Commands.CreateScreenshot
{
    public class CreateScreenshotDto : IMapWith<CreateScreenshotCommand>
    {
        [Required]
        public string? Base64 { get; set; }
        public DateTime? CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateScreenshotDto, CreateScreenshotCommand>()
                .ForMember(screenshotCommand => screenshotCommand.Base64,
                    opt => opt.MapFrom(screenshotDto => screenshotDto.Base64))
                .ForMember(screenshotCommand => screenshotCommand.CreateDate,
                    opt => opt.MapFrom(screenshotDto => screenshotDto.CreateDate));
        }
    }
}
