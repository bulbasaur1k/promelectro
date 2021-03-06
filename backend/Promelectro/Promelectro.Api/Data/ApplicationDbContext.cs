﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Promelectro.Api.Models;

namespace Promelectro.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
            builder.Entity<UserToken>().ToTable("UserToken");
            builder.Entity<User>().Property(x => x.FirstName).HasMaxLength(128);
            builder.Entity<User>().Property(x => x.LastName).HasMaxLength(128);
            builder.Entity<User>().Property(x => x.Surname).HasMaxLength(128);
            builder.Entity<Role>().Property(x => x.Description).HasMaxLength(500);

            var file = builder.Entity<File>();
            file.Property(x => x.Description).HasMaxLength(250).IsRequired();
            file.Property(x => x.DateLoad).IsRequired();
            file.Property(x => x.UserId).IsRequired();

            var post = builder.Entity<Post>();
            post.Property(x => x.Name).HasMaxLength(250).IsRequired();
            post.Property(x => x.Text).IsRequired();
            post.Property(x => x.DateCreate).IsRequired();
        }
    }
}