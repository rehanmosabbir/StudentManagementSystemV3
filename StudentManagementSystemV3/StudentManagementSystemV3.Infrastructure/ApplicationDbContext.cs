using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagementSystemV3.Core.Models;

namespace StudentManagementSystemV3.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));

            // in memory database used for simplicity, change to a real db for production applications
            //options.UseInMemoryDatabase("InMemoryDb");
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentModel>()
                .HasMany(s => s.CoursesAttended)
                .WithMany(sc => sc.Students);

            modelBuilder.Entity<StudentModel>()
                .HasMany(sc => sc.SemestersAttended)
                .WithMany(c => c.Students);

        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<CourseModel> Courses { get; set; }

    }
}
