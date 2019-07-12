using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.DAL.Context
{
    public class SampleContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
