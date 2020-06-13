using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TextApp.Infrastructure.Texts;
using TextApp.Infrastructure.Users;

namespace TextApp.Infrastructure
{
    public class TextDBContext : IdentityDbContext
    {
        public TextDBContext(DbContextOptions<TextDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Text> Texts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Text>().HasKey(text => new { text.ID });

            builder.Entity<Text>().HasOne<User>(user => user.User).WithMany(text => text.Texts).HasForeignKey(text => text.UserID);

        }
    }
}
