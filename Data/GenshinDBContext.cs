using Microsoft.EntityFrameworkCore;
using GenshinDB.Models;

namespace GenshinDB.Data
{
    public class GenshinDBContext : DbContext
    {
        public GenshinDBContext (DbContextOptions<GenshinDBContext> options)
            : base(options)
        {
        }

        public DbSet<Artifact> Artifact { get; set; }
    }
}