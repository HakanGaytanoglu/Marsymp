using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marsymp.Models.ORM.Entity;
using System.Data.Entity;


namespace Marsymp.Models.ORM.Context
{
    public class ProjectContext : DbContext
    {

        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=; DataBase=; User Id=; Password=;"; 
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }

        // we override the OnModelCreating method here.

    }
}