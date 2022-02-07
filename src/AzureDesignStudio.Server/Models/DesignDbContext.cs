using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Server.Models
{
    public class DesignDbContext : DbContext
    {
        public DesignDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesignModel>()
                .HasCheckConstraint("ADS_CHECK_JSON", "ISJSON(DesignData)=1");
        }

        public DbSet<DesignModel> AdsDesigns { get; set; } = null!;
    }

    public record DesignModel
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = null!;
        public Guid UserId { get; set; }
        public string DesignData { get; set; } = null!;
        public DateTime LastModified { get; set; }
    }
}
