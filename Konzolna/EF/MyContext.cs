using System;
using System.Collections.Generic;
using System.Text;
using Konzolna.Models;
using Microsoft.EntityFrameworkCore;

namespace Konzolna.EF
{
    public class MyContext:DbContext
    {
        public  DbSet<Kupac> Kupac { get; set; }
        public DbSet<Opstina> Opstina { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=OpstinaKupac;User=hari;Password=hari;");
        }
    }
}
