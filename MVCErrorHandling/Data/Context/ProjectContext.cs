using MVCErrorHandling.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCErrorHandling.Data.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-IPLQK1T;Database=ExceptionDB;Integrated Security=True;";
        }

        public DbSet<ErrorLog> Logs { get; set; }

    }
}