using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataModel>().HasData(new DataModel { Id = 1, Name = "fx999", Desc = "Model" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => base.OnConfiguring(optionsBuilder);

        public DbSet<DataModel> Models { get; set; }
    }
}
