using System.Threading;
using System.Threading.Tasks;
using EloRating.Core.Interfaces;
using EloRating.Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EloRating.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<StoredEvent> StoredEvents { get; set; }
    }
}
