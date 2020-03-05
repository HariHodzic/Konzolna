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
        public DbSet<StavkaFakture> Opstina { get; set; }

        public DbSet<StavkaFakture> StavkaFakture { get; set; }
        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=OpstinaKupac;User=hari;Password=hari;");
        }
    }
}
