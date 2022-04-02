using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
   public  class PregledNarudzbi
    {
        public int PregledNarudzbiId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public decimal MinIznos { get; set; }
        public decimal IznosNarudzbe { get; set; }
        public int ProizvodiId { get; set; }
        public Proizvodi Proizvodi { get; set; }
        public int KupciId { get; set; }
        public Kupci Kupci { get; set; }
    }
}
