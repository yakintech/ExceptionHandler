using MVCErrorHandling.Data.Context;
using MVCErrorHandling.Data.Entities;
using MVCErrorHandling.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCErrorHandling.Infrastructure
{
    public class Logger : IErrorLogger<ErrorLog>
    {
        private ProjectContext _db;

        public Logger()
        {
            _db = new ProjectContext();
        }

        public void Log(ErrorLog entity)
        {
            entity.TimeStamp = DateTime.Now;
            _db.Logs.Add(entity);
            _db.SaveChanges();

        }
    }
}