using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konzolna.Models
{
    class Kupac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }
        

        public int OpstinaID { get; set; }

        [ForeignKey("OpstinaID")]
        public Opstina Opstina { get; set; }
    }
}
