using Microsoft.EntityFrameworkCore;
using TeamInternationalTestEf.Models;

namespace TeamInternationalTestEf.EF
{
    public class TestDbContext : DbContext
    {
        public DbSet<FileMessage> FileMessages { get; set; }

        public DbSet<TextMessage> TextMessages { get; set; }

        public DbSet<User> Users { get; set; }


        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies(true).UseSqlServer(Resource1.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileMessage>(e =>
            {
                e.ToTable("FileMessages");
                e.HasKey(p => p.Id);

                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Data).IsRequired();
                e.Property(p => p.Name).HasMaxLength(100).IsRequired();
                e.Property(p => p.ContentType).HasMaxLength(80).IsRequired();
                e.Property(p => p.CreationTime).IsRequired();
                e.Property(p => p.UserId).IsRequired();

                e.HasOne(fm => fm.User).WithMany(u => u.FileMessages).OnDelete(DeleteBehavior.Cascade).HasForeignKey(fm => fm.UserId);
            });
            builder.Entity<TextMessage>(e =>
            {
                e.ToTable("TextMessages");
                e.HasKey(p => p.Id);

                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Content).IsRequired();
                e.Property(p => p.CreationTime).IsRequired();
                e.Property(p => p.UserId).IsRequired();

                e.HasOne(tm => tm.User).WithMany(u => u.TextMessages).OnDelete(DeleteBehavior.Cascade).HasForeignKey(tm => tm.UserId);
            });
            builder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(p => p.Id);
                e.HasIndex(e => e.Username).IsUnique();

                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
                e.Property(p => p.LastName).IsRequired().HasMaxLength(30);
                e.Property(p => p.Username).IsRequired().HasMaxLength(30);
                e.Property(p => p.Password).IsRequired().HasMaxLength(30);
            });
        }
    }
}
