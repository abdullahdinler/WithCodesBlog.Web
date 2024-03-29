﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class WithCodesContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public WithCodesContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommentAnswer>()
                .HasOne(ca => ca.Comment)
                .WithMany(c => c.CommentAnswers)
                .HasForeignKey(ca => ca.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }


        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Notification>? Notifications { get; set; }
        public DbSet<SocialMedia>? SocialMediae { get; set; }
        public DbSet<Hashtag>? Hashtags { get; set; }
        public DbSet<CommentAnswer>? CommentAnswers { get; set; }


    }
}
