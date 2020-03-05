using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Konzolna.Models
{
    public class StavkaFakture
    {
        public int Id { get; set; }
        public int FakturaID { get; set; }
        [ForeignKey("FakturaID")]
        public Faktura Faktura { get; set; }

        public int ProizvodID { get; set; }
        [ForeignKey("ProizvodID")]
        public Proizvod Proizvod { get; set; }

        public int Kolicina { get; set; }

    }
}
