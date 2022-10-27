using MediatR;

namespace Screenshoter.Application.Interaction.Commands.DeleteScreenshot
{
    public class DeleteScreenshotCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
