using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konzolna.Models
{
    public class Faktura
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        public int KupacID { get; set; }

        [ForeignKey("KupacID")]
        public Kupac Kupac { get; set; }

    }
}
