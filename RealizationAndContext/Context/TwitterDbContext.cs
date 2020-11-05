using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Twitter.Domain.Models;

namespace Twitter.RealizationAndContext
{
    public class TwitterDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        public TwitterDbContext(DbContextOptions<TwitterDbContext> options) : base(options)
        {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .Property(p => p.Full_name)
                        .IsUnicode(false);

            modelBuilder.Entity<User>()
                        .Property(p => p.User_login)
                        .IsUnicode(false);
            
            modelBuilder.Entity<User>()
                        .Property(p => p.User_password)
                        .IsUnicode(false);

            modelBuilder.Entity<User>()
                        .Property(p => p.Birth)
                        .IsUnicode(false);

            modelBuilder.Entity<User>()
                        .Property(p => p.Registration_date)
                        .IsUnicode(false);

            modelBuilder.Entity<User>()
                        .Property(p => p.Photo_path)
                        .IsUnicode(false);

            modelBuilder.Entity<Tweet>()
                        .Property(p => p.Tweet_description)
                        .IsUnicode(false);

            modelBuilder.Entity<Tweet>()
                        .Property(p => p.Creation_date)
                        .IsUnicode(false);
        }
    }
}