using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Models;
using Microsoft.EntityFrameworkCore;

namespace JobService.Data
{
    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public JobDBContext(DbContextOptions<JobDBContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Job>().ToTable("job");
        //}
    }
}