using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;


namespace integralApi.Data
{
    public class IntegralContext : DbContext
    {
        public DbSet<Eq> Expressions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Database=IntegralApi;Username=postgres;Password=Sabexzero123");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
