using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;

namespace EFTest
{
    class TestContext : DbContext
    {
        private string _dbFile;

        public DbSet<Parent> Parents { get; set; }

        public TestContext(string dbFile)
        {
            _dbFile = dbFile;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = _dbFile };
            var sqliteConnection = new SqliteConnection(connectionStringBuilder.ToString());
            optionsBuilder.UseSqlite(sqliteConnection);
        }

        public void Initialize()
        {
            Database.Migrate();
        }
    }
}
