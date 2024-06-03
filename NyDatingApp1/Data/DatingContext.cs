using Microsoft.EntityFrameworkCore;
using NyDatingApp1.Models;
using System.Reflection;

namespace NyDatingApp1.Data
{
    public class datingdatabase : DbContext
    {
        public datingdatabase(DbContextOptions<datingdatabase> options)
            : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()"); // or .HasDefaultValue(DateTime.Now) for non-SQL Server databases

            modelBuilder.Entity<Like>()
               .Property(e => e.Status)
               .HasDefaultValueSql("0");

            modelBuilder.Entity<Message>()
               .Property(e => e.Status)
               .HasDefaultValueSql("0");

            modelBuilder.Entity<City>()
                .HasIndex(b => b.CityName)
                .IsUnique()
                .HasFilter(null);

            modelBuilder.Entity<City>()
            .Property(et => et.Id)
            .ValueGeneratedNever();

            // Configure the many-to-many relationship between UserProfile and Like
            modelBuilder.Entity<Like>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Liker)
                .WithMany(u => u.LikedUsers)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Likee)
                .WithMany(u => u.LikedByUsers)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            // Additional configurations for UserProfile entity if needed
            modelBuilder.Entity<Profile>()
                .HasMany(u => u.LikedUsers)
                .WithOne(l => l.Liker)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Profile>()
                .HasMany(u => u.LikedByUsers)
                .WithOne(l => l.Likee)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            //-------------
            // Configure the many-to-many relationship between UserProfile and Message
            modelBuilder.Entity<Message>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Message>()
                .HasOne(l => l.Sender)
                .WithMany(u => u.ReceivedByUsers)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            modelBuilder.Entity<Message>()
                .HasOne(l => l.Receiver)
                .WithMany(u => u.SentByUsers)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            // Additional configurations for UserProfile entity if needed
            modelBuilder.Entity<Profile>()
                .HasMany(u => u.LikedUsers)
                .WithOne(l => l.Liker)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Profile>()
                .HasMany(u => u.LikedByUsers)
                .WithOne(l => l.Likee)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
