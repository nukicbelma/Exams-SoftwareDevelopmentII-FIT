using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class NarudzbeSearchRequest
    {
        public int ProizvodiId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public decimal MinIznos { get; set; }
    }
}
