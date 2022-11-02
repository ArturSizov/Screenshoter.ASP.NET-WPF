using MediatR;

namespace Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList
{
    public class GetScreenshotListQuery : IRequest<ScreenshotList>
    {
        public Guid Id { get; set; }
    }
}
