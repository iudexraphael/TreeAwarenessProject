using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;
using TreeAwareness.Model;

namespace TreeAwareness.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TreeInfo> Trees { get; set; }
        public DbSet<UserMessages> Messages { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Tree.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");

            string dbPath1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Message.db");
            optionsBuilder.UseSqlite($"Filename={dbPath1}");
        }


    }
}
