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

        public DataContext()
        {

        }

                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataModel>().HasData(new DataModel { Id = 1, Name = "fx999", Desc = "Model" });
        }

        public DbSet<DataModel> Models { get; set; }
    }
}
