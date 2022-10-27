using MediatR;

namespace Screenshoter.Application.Interaction.Commands.CreateScreenshot
{
    public class CreateScreenshotCommand : IRequest<Guid>
    {
        public string? Base64 { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
