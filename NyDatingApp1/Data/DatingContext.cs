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
        //public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()"); 

            modelBuilder.Entity<Like>()
               .HasOne(l => l.SenderProfile)
               .WithMany(p => p.SentLikes)
               .HasForeignKey(l => l.SenderId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.ReceiverProfile)
                .WithMany(p => p.ReceivedLikes)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.City)
                .WithMany(c => c.Profiles)
                .HasForeignKey(p => p.CityId);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Profile)
                .HasForeignKey<Profile>(p => p.AccountId);
            
        }
    }
}