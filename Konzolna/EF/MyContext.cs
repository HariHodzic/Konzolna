using System;
using System.Collections.Generic;
using System.Text;
using Konzolna.Models;
using Microsoft.EntityFrameworkCore;

namespace Konzolna.EF
{
    public class MyContext:DbContext
    {
        DbSet<Kupac> Kupac { get; set; }
        DbSet<Opstina> Opstina { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
