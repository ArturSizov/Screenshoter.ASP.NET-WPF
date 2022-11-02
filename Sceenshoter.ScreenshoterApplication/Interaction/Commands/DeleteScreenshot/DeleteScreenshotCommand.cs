using MediatR;

namespace Screenshoter.ScreenshoterApplication.Interaction.Commands.DeleteScreenshot
{
    public class DeleteScreenshotCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
