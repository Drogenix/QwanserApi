using Microsoft.EntityFrameworkCore;
using QwanserApi.Entity;
using QwanserApi.Entity.Notification;

namespace QwanserApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Socials> Socials { get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Question> QuestionTags { get; set; }
    }
}
