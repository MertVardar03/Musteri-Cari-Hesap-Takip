using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriCariTakip
{
    public class OdemeBorc
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Tür { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public string musteri_id { get; set; }
    }
}
