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
    public partial class MusteriDuzenle : Form
    {
        CustomerList customerList = new CustomerList();
        private int customerId; // Müşteri idsini tutacak değişken
        private AnaSayfa anaForm;

        public MusteriDuzenle(int selectedCustomerId, AnaSayfa anaSayfa)
        {
            InitializeComponent();
            customerId = selectedCustomerId; // müşteri idsinni al
            this.anaForm = anaSayfa;
        }

        private void MusteriDuzenle_Load(object sender, EventArgs e)
        {
            
            Customer selectedCustomer = customerList.customers.FirstOrDefault(c => c.Id == customerId);
            if (selectedCustomer != null)
            {
                textBoxAd.Text = selectedCustomer.Ad;
                textBoxSoyad.Text = selectedCustomer.Soyad;
                textBoxFirma.Text = selectedCustomer.Firma_ismi;
                textBoxTel.Text = selectedCustomer.Telefon;
                textBoxAdres.Text = selectedCustomer.Adres;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxAd.Text) ||
                    string.IsNullOrWhiteSpace(textBoxSoyad.Text) ||
                    string.IsNullOrWhiteSpace(textBoxFirma.Text))
                {
                    throw new Exception("Lütfen Zorunlu alanları doldurunuz.");
                }

                Customer updatedCustomer = new Customer
                {
                    Id = customerId, 
                    Ad = textBoxAd.Text,
                    Soyad = textBoxSoyad.Text,
                    Firma_ismi = textBoxFirma.Text,
                    Telefon = textBoxTel.Text,
                    Adres = textBoxAdres.Text
                };

                customerList.UpdateCustomer(updatedCustomer); 
                MessageBox.Show("Müşteri güncellendi.");
                anaForm.YenileAnaForm();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string ozelMesaj = "Müşteri Düzenleme Sırasında Bir Hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }
        }

    }

}
