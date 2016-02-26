using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Diagnostics;

namespace School.Model
{
    public class WorldContext:DbContext 
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists("..\\Data"))
            {
                var info = Directory.CreateDirectory("..\\Data");
                Debug.WriteLine(info);
            } 
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "..\\Data\\test.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);

            base.OnConfiguring(optionsBuilder);
        }

        private String getProjectDirectory()
        {
           return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; ;
        }

    }
}
