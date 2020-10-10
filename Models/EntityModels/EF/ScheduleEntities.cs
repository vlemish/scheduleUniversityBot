using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testDbMySql.Models;

namespace scheduleUniversityDb.EF
{
    class ScheduleEntities : DbContext
    {
        public ScheduleEntities()
            : base("name = MS SQL") { }

        public virtual DbSet<Monday> Mondays { get; set; }

        public virtual DbSet<Subject> Subjects_ { get; set; }

        public virtual DbSet<Teacher> Teachers_ { get; set; }

        public virtual DbSet<Tuesday> Tuesdays { get; set; }

        public virtual DbSet<Wednesday> Wednesdays { get; set; }

        public virtual DbSet<Thursday> Thursdays { get; set; }

        public virtual DbSet<Friday> Fridays { get; set; }

        public virtual DbSet<Holiday> Holidays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>().HasRequired(e => e.Subjects).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Teacher>().HasMany(e => e.Subjects).WithRequired(e => e.Teacher).WillCascadeOnDelete(false);
            modelBuilder.Entity<Subject>().HasMany(e => e.Mondays).WithRequired(e => e.Subjects).HasForeignKey(e => e.TeacherId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Subject>().HasMany(e => e.Tuesdayds).WithRequired(e => e.Subjects).HasForeignKey(e => new { e.TeacherId }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Subject>().HasMany(e => e.Wednesdays).WithRequired(e => e.Subjects).HasForeignKey(e => new { e.TeacherId }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Subject>().HasMany(e => e.Thursdays).WithRequired(e => e.Subjects).HasForeignKey(e => new { e.TeacherId }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Subject>().HasMany(e => e.Fridays).WithRequired(e => e.Subjects).HasForeignKey(e => new { e.TeacherId }).WillCascadeOnDelete(false);

        }
    }
}