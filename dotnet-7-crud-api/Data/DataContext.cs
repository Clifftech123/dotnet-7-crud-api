using dotnet_7_crud_api.Entitiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using dotnet_7_crud_api.Helpers;

namespace dotnet_7_crud_api.Data
{
    public class DataContext : DbContext
    {
        private readonly DbSettings _dbSettings;

        public DataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("dotnet-7-crud-api")
            .HasKey(x => x.Guid);
           
        }
    }
}