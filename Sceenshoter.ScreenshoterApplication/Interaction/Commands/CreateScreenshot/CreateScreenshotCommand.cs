using MediatR;

namespace Screenshoter.ScreenshoterApplication.Interaction.Commands.CreateScreenshot
{
    public class CreateScreenshotCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Base64 { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
