using Microsoft.EntityFrameworkCore;
using Sceenshoter.Domain.Models;

namespace Sceenshoter.Application.Interfaces
{
    public interface IScreenshoterDbContext
    {
        DbSet<Screenshot> Screenshots { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
