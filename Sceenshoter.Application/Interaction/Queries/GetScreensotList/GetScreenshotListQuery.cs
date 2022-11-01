using MediatR;

namespace Sceenshoter.Application.Interaction.Queries.GetScreensotList
{
    public class GetScreenshotListQuery : IRequest<ScreenshotList>
    {
        public Guid UserId { get; set; }
    }
}
