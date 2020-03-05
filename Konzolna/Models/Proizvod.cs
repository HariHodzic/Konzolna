using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konzolna.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string JedinicaMjere { get; set; }

        public float Cijena { get; set; }
    }
}
