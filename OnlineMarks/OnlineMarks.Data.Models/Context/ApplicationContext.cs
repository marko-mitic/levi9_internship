using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models.Context
{
    public class ApplicationContext : DbContext
    {
        private IDbContextTransaction dbContextTransaction;

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subject>()
                .HasOne(p => p.Professor)
                .WithMany(p => p.Subjects);

            builder.Entity<Grade>()
                .HasOne(p => p.SubjectGrade)
                .WithMany(p => p.Grades);

            builder.Entity<Parent>()
                .HasMany(p => p.Children)
                .WithOne(p => p.Parent);

            builder.Entity<StudentSubject>()
                .HasKey(t => new { t.StudentId, t.SubjectId });

            builder.Entity<StudentSubject>()
                .HasOne(pt => pt.Subject)
                .WithMany(p => p.StudentSubjects)
                .HasForeignKey(pt => pt.SubjectId);

            builder.Entity<StudentSubject>()
                .HasOne(pt => pt.Student)
                .WithMany(t => t.StudentSubjects)
                .HasForeignKey(pt => pt.StudentId);

            builder.Entity<User>()
                .HasAlternateKey(a => a.Name);

            builder.Entity<Subject>()
                .HasAlternateKey(a => a.Name);
        }

        public DbSet<User> Users { get; set; } // Db sets should be made from models that extend user
        public DbSet<SubjectGrade> SubjectGrades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void CommitTransaction()

        {

            if (dbContextTransaction != null)

            {

                dbContextTransaction.Commit();

            }

        }
        public void DisposeTransaction()

        {

            if (dbContextTransaction != null)

            {

                dbContextTransaction.Dispose();

            }

        }
    }
}
