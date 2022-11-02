using MediatR;
using Sceenshoter.ScreenshoterApplication.Interfaces;
using Sceenshoter.Domain.Models;
using Screenshoter.ScreenshoterApplication.Common.Exceptions;

namespace Screenshoter.ScreenshoterApplication.Interaction.Commands.DeleteScreenshot
{
    public class DeleteScreenshotCommandHandler : IRequestHandler<DeleteScreenshotCommand>
    {
        private IScreenshoterDbContext _dbContext;

        public DeleteScreenshotCommandHandler(IScreenshoterDbContext dbContext) => _dbContext = dbContext;


        public async Task<Unit> Handle(DeleteScreenshotCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Screenshots
               .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Screenshot), request.Id);
            }

            _dbContext.Screenshots.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
