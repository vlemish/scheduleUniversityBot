using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ScheduleTelegramBotDb.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ScheduleTelegramBotDb.EF
{
    class ScheduleContext : DbContext
    {

        public ScheduleContext(DbContextOptions<ScheduleContext> options):
            base(options)
        {

        }

        public ScheduleContext()
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-To-Many
            modelBuilder.Entity<Group>().HasMany(g => g.Students).WithOne(s => s.Groups);

            //Many-To-Many (Group - Subject)
            modelBuilder.Entity<GroupSubjects>().HasKey(gc => new { gc.GroupId, gc.SubjectId });
            modelBuilder.Entity<GroupSubjects>().HasOne(gc => gc.Group).WithMany(g => g.GroupSubjects).HasForeignKey(gc => gc.GroupId);
            modelBuilder.Entity<GroupSubjects>().HasOne(gc => gc.Subject).WithMany(s => s.GroupSubjects).HasForeignKey(gc => gc.SubjectId);

            //Many-To-Many (Teacher - Subject)
            modelBuilder.Entity<TeacherSubjects>().HasKey(ts => new { ts.SubjectId, ts.TeacherId });
            modelBuilder.Entity<TeacherSubjects>().HasOne(ts => ts.Teacher).WithMany(t => t.TeacherSubjects).HasForeignKey(ts => ts.TeacherId);
            modelBuilder.Entity<TeacherSubjects>().HasOne(ts => ts.Subject).WithMany(s => s.TeacherSubjects).HasForeignKey(ts => ts.SubjectId);

        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionstring =
                @"server=DESKTOP-QDUNKHJ\SQLEXPRESS;database=scheduleDb;
                integrated security=True; MultipleActiveResultSets=True;
                App=EntityFramework;";
                optionsBuilder.UseSqlServer(connectionstring,
                options => options.EnableRetryOnFailure());
              //  .ConfigureWarnings(warnings =>
              //warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }
    }
}
