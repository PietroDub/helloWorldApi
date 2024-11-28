//using helloWorldApi.Models;
using helloWorldApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace helloWorldApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appuser> Appusers {  get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Appcontact> Appontacts { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Appuser>().ToTable("users");
            builder.Entity<Course>().ToTable("courses");
            builder.Entity<Sale>().ToTable("sales");
            builder.Entity<Appcontact>().ToTable("contacts");
            builder.Entity<Quiz>().ToTable("quizzes");
        }
    }
}
