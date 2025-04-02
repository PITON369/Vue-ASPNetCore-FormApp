using Microsoft.EntityFrameworkCore;
using ServerAPI.Models;
using System.Text.Json;

namespace ServerAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Submit> Submits { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submit>()
                .Property(e => e.Data)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null));
        }
    }
}
