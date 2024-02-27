using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MusteriCariTakip
{
    public partial class Form1 : Form
    {
        private KullaniciKontrol kullanicikontrol;

        public Form1()
        {
            InitializeComponent();
            kullanicikontrol = new KullaniciKontrol();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string kullaniciadi = textBox1.Text;
                string sifre = textBox2.Text;

                Kullanici kullanici = new Kullanici
                {
                    kullanici_adi = kullaniciadi,
                    sifre = sifre
                };

                string yetki = kullanicikontrol.KullaniciDogrula(kullanici);

                if (!string.IsNullOrEmpty(yetki))
                {
                    if (yetki == "admin" || yetki == "user")
                    {

                        // Admin yetkisi varsa yapılacak işlemler
                        AnaSayfa AnaSayfa = new AnaSayfa();
                        AnaSayfa.YetkiKontrol(yetki);
                        AnaSayfa.Show();
                        this.Hide();
                    }

                 
                    
                }
                else
                {
                    throw new Exception("Kullanıcı adı ve şifreyi kontrol edin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string ozelMesaj = "Kullanıcı girişi sırasında hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }
        }
    }
}
