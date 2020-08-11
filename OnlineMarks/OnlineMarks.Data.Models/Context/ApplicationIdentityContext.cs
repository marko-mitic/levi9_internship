using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineMarks.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models.Context
{
    public class ApplicationIdentityContext : IdentityDbContext<User>, IApplicationContext
    {
        private IDbContextTransaction dbContextTransaction;

        public ApplicationIdentityContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } //Db sets should be made from models that extend user

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
