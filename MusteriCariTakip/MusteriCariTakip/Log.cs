using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriCariTakip
{
    public class Log
    {
        public int Id { get; set; }
        public string OzelMesaj { get; set; }
        public string HataMesaji { get; set; }
        public string HataStackTrace { get; set; }
        public string KullaniciAdi { get; set; }
        public DateTime Tarih { get; set; }
    }
}
