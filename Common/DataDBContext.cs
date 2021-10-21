using Common.AutofacManager;
using Entity;
using Entity.Common;
using Entity.Manage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Mapping.Common;
using Utility.Mapping.Manage;

namespace Common
{
   public  class DataDBContext:DbContext
    {
        public DataDBContext()
          {
  
          }
  
        public DataDBContext(DbContextOptions<DataDBContext> options):base(options)
        {

        }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleToModule> RoleToModule { get; set; }
        public DbSet<Logger>  Logger { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Manager>(new ManagerMap());
            modelBuilder.ApplyConfiguration<Module>(new ModuleMap());
            modelBuilder.ApplyConfiguration<Role>(new RoleMap());
            modelBuilder.ApplyConfiguration<RoleToModule>(new RoleToModuleMap());
            modelBuilder.ApplyConfiguration<Logger>(new LoggerMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = DBServerProvider.GetConnectionString(null);
            //if (Const.DBType.Name == Enums.DbCurrentType.MsSql.ToString())
            //{
            //    optionsBuilder.UseSqlServer(connectionString);

            // }
            var connection = AppSetting.DbConnectionString;
            optionsBuilder = optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlServer(connection);
        }

    }
}
