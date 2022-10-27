using MediatR;
using Microsoft.EntityFrameworkCore;
using Sceenshoter.Application.Interfaces;
using Sceenshoter.Domain.Models;
using Screenshoter.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screenshoter.Application.Interaction.Commands.DeleteScreenshot
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
