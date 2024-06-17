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
               .Property(e => e.Status)
               .HasDefaultValueSql("0");



            modelBuilder.Entity<City>()
                .HasIndex(b => b.CityName)
                .IsUnique()
                .HasFilter(null);

            modelBuilder.Entity<City>()
            .Property(et => et.CityId)
            .ValueGeneratedNever();

            //// Configure the many-to-many relationship between UserProfile and Like
            //modelBuilder.Entity<Like>()
            //    .HasKey(l => l.LikeId);

            //modelBuilder.Entity<Like>()
            //    .HasOne(l => l.SenderProfile)
            //    .WithMany(u => u.ReceivedLikes)
            //    .HasForeignKey(l => l.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            //modelBuilder.Entity<Like>()
            //    .HasOne(l => l.ReceiverProfile)
            //    .WithMany(u => u.ReceivedLikes)
            //    .HasForeignKey(l => l.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict); // Set the appropriate delete behavior

            //// Additional configurations for UserProfile entity if needed
            //modelBuilder.Entity<Profile>()
            //    .HasMany(u => u.SentLikes)
            //    .WithOne(l => l.SenderProfile)
            //    .HasForeignKey(l => l.LikeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Profile>()
            //    .HasMany(u => u.ReceivedLikes)
            //    .WithOne(l => l.ReceiverProfile)
            //    .HasForeignKey(l => l.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            ////-------------


            //// Additional configurations for UserProfile entity if needed
            //modelBuilder.Entity<Profile>()
            //    .HasMany(u => u.ReceivedLikes)
            //    .WithOne(l => l.SenderProfile)
            //    .HasForeignKey(l => l.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Profile>()
            //    .HasMany(u => u.ReceivedLikes)
            //    .WithOne(l => l.ReceiverProfile)
            //    .HasForeignKey(l => l.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);
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
                .HasMany(p => p.SentLikes)
                .WithOne(l => l.SenderProfile)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Juster DeleteBehavior efter behov

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.ReceivedLikes)
                .WithOne(l => l.ReceiverProfile)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Juster DeleteBehavior efter behov

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Profile)
                .HasForeignKey<Profile>(p => p.AccountId)
                .OnDelete(DeleteBehavior.Cascade); // Juster efter dine behov

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.City)
                .WithMany(c => c.Profiles)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict); // Juster efter dine behov



        }
    }
}