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
            base.OnModelCreating(builder);
        }

        public DbSet<User> AppUsers { get; set; } //Db sets should be made from models that extend user

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
