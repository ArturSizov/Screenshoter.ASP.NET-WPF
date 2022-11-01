using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sceenshoter.Application.Interfaces;
using Sceenshoter.Domain.Models;
using Screenshoter.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceenshoter.Application.Interaction.Queries.GetScreensotList
{
    public class GetScreenshotListQueryHandler : IRequestHandler<GetScreenshotListQuery, ScreenshotList>
    {
        private IScreenshoterDbContext _dbContext;
        private IMapper _mapper;

        public GetScreenshotListQueryHandler(IScreenshoterDbContext dbContext,  IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

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
