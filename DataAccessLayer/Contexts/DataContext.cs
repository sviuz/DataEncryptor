using BLL.DTO;
//?using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelDTO>().HasData(new ModelDTO { Id = 1, Name = "fx999", Desc = "Model" });
        }

        public DbSet<ModelDTO> Models { get; set; }
    }
}
