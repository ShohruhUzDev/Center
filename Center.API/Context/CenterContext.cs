using Center.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public class CenterContext :IdentityDbContext<ApiUser>
    {
        public CenterContext(DbContextOptions<CenterContext> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasOne(p => p.Teacher)
                .WithMany(u => u.Groups)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Group>()
               .HasOne(p => p.Subject)
               .WithMany(u => u.Groups)
               .OnDelete(DeleteBehavior.SetNull);

            // modelBuilder.ApplyConfiguration(new RoleConfiguration());

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });


        }
    }
}
