using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Map;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class SchoolSystemDbContext : DbContext
    {
        public SchoolSystemDbContext(DbContextOptions<SchoolSystemDbContext> options) : base(options)
        {
        }

        public DbSet<SchoolModel> School { get; set; }

        public DbSet<TeacherModel> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new SchoolMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=senha123;Database=db");
        }
    }
}