using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Placement> Placements { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Worker> Workers { get; set; }

        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>(b =>
            {
                b.Property(e => e.Role)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
            });
        }
    }
}
