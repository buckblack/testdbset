using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace test.Entity
{
    public class DbTestContext: DbContext
    {
        public IConfiguration configuration;
        public DbTestContext(DbContextOptions<DbTestContext> options) : base(options)
        {
        }
        public DbTestContext(DbContextOptions<DbTestContext> options, IConfiguration config) : base(options)
        {
            configuration = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            optionsBuilder.EnableSensitiveDataLogging()
                .UseSqlServer(server).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<roleEntity> Roles { get; set; }
        public DbSet<DataSet> StatisticalUserViews { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<StatisticalUserViewEntity>().ToView("StatisticalUserViews");
            
        //}
    }
}
