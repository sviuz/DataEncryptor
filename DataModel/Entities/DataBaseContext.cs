using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities
{
    public class DataBaseContext :DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataBaseModel>().HasData(new DataBaseModel { Id = 1, Name = "qwerty", Description = "qwerty" });
        }

        public DbSet<DataBaseModel> Models { get; set; }
    }
}
