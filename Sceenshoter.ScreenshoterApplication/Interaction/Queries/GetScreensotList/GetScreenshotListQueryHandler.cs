using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using Sceenshoter.ScreenshoterApplication.Interfaces;

namespace Screenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList
{
    public class GetScreenshotListQueryHandler : IRequestHandler<GetScreenshotListQuery, ScreenshotList>
    {
        private IScreenshoterDbContext _dbContext;
        private IMapper _mapper;

        public GetScreenshotListQueryHandler(IScreenshoterDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ScreenshotList> Handle(GetScreenshotListQuery request, CancellationToken cancellationToken)
        {
            var screenshotQuery = await _dbContext.Screenshots
                .Where(screenshot => screenshot.Id == screenshot.Id)
                .ProjectTo<ScreenshotLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ScreenshotList { Screenshots = screenshotQuery };
        }
    }
}
