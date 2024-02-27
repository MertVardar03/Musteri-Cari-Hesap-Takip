using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriCariTakip
{
    public partial class MusteriEkle : Form
    {
        private CustomerList customerList;
        private AnaSayfa anaForm;
        public MusteriEkle(AnaSayfa anaSayfa)
        {
            InitializeComponent();

            customerList = new CustomerList();

            this.anaForm = anaSayfa;
        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ad = textBoxAd.Text;
                string soyad = textBoxSoyad.Text;
                string telefon = textBoxTel.Text;
                string adres = textBoxAdres.Text;
                string firmaIsmi = textBoxFirma.Text;

                if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                    string.IsNullOrWhiteSpace(firmaIsmi))
                {
                    throw new Exception("Lütfen Zorunlu alanları doldurunuz.");
                }

                Customer addcustomer = new Customer
                {
                    Ad = ad,
                    Soyad = soyad,
                    Telefon = telefon,
                    Adres = adres,
                    Firma_ismi = firmaIsmi,
                };

                customerList.addCustomer(addcustomer);

                MessageBox.Show("Müşteri başarıyla eklendi.");
                this.Close(); // Formu kapat
                anaForm.YenileAnaForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string ozelMesaj = "Müşteri Ekleme Sırasında Bir Hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }
        }

    }
}
