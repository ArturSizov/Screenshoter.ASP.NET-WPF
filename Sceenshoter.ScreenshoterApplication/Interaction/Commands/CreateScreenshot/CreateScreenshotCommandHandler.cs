using MediatR;
using Sceenshoter.ScreenshoterApplication.Interfaces;
using Sceenshoter.Domain.Models;

namespace Screenshoter.ScreenshoterApplication.Interaction.Commands.CreateScreenshot
{
    public class CreateScreenshotCommandHandler : IRequestHandler<CreateScreenshotCommand, Guid>
    {
        private IScreenshoterDbContext _dbContext;

        public CreateScreenshotCommandHandler(IScreenshoterDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Guid> Handle(CreateScreenshotCommand request, CancellationToken cancellationToken)
        {
            var screenshot = new Screenshot
            { 
                Id = request.Id,
                Base64 = request.Base64,
                CreateDate = DateTime.Now
            };

            await _dbContext.Screenshots.AddAsync(screenshot, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return screenshot.Id;
        }
    }
}
