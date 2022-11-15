using AutoMapper;
using Prism.Mvvm;
//using DevExpress.Mvvm; TODO: получаю null в полях. Причину не понял
using Sceenshoter.Domain.Models;
using Screenshoter.ScreenshoterApplication.Common.Mappings;

namespace Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList
{
    public class ScreenshotLookupDto : BindableBase, IMapWith<Screenshot>
    {
        private Guid _id;

        private string? _base64;

        private DateTime _createDate;

        public Guid Id { get => _id; set => SetProperty(ref _id, value); }
        public string? Base64 { get => _base64; set => SetProperty(ref _base64, value); }
        public DateTime CreateDate { get => _createDate; set => SetProperty(ref _createDate, value); }

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
