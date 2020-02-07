using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konzolna.Models
{
    public class Kupac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }

        //[Column("OpstinaRodjenjaID")]
        //public int OpstinaID { get; set; }

        public int OpstinaRodjenjaID { get; set; }
        [ForeignKey("OpstinaRodjenjaID")]
        public Opstina OpstinaRodjenja { get; set; }

        public int OpstinaPrebivalistaID { get; set; }
        [ForeignKey("OpstinaPrebivalistaID")]
        public Opstina OpstinaPrebivalista { get; set; }
    }
}
