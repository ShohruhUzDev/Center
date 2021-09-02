using Center.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public class CenterContext : DbContext
    {
        public CenterContext(DbContextOptions<CenterContext> options):base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentGroup>()
                .HasOne(i => i.Student)
                .WithMany(u => u.StudentGroups)
                .HasForeignKey(n => n.StudentId);
            modelBuilder.Entity<StudentGroup>()
               .HasOne(i => i.Group)
               .WithMany(u => u.StudentGroups)
               .HasForeignKey(n => n.GroupId);
        }
    }
}
