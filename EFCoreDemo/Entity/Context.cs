using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace EFCoreDemo.Entity
{
    public class Context : DbContext
    {
        

        public Context()
        {

        }
        public virtual DbSet<TestAccounts> _UserInfo { get; set; }
        public virtual DbSet<TestAccounts> _UserInfoX { get; }
        public virtual DbSet<Agent_User> _Agent_User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestAccounts>(b =>
            {
                b.ToTable("TestAccounts");
                b.HasKey(x => x.UserID);
                b.HasIndex(x => x.UserID).IsUnique();
            });
            modelBuilder.Entity<Agent_User>(b =>
            {
                b.ToTable("Agent_User");
                b.HasKey(x => x.ID);
                b.HasIndex(x => x.ID).IsUnique();
            });
            // base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=47.107.107.33,8000;Database=RYAccountsDB;User ID=sa;Password=9emRFMgVJqX");


            //打印日志
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            options.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(options);
        }
        
    }
}
