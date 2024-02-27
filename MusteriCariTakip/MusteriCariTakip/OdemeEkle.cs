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
    public partial class OdemeEkle : Form
    {
        private OdemeList odemeList;
        private CustomerList customerList = new CustomerList();
        private int customerId;

        public OdemeEkle(int selectedCustomerId)
        {
            InitializeComponent();
            odemeList = new OdemeList();
            customerId = selectedCustomerId;
        }

        private void OdemeEkle_Load(object sender, EventArgs e)
        {
            Customer selectedCustomer = customerList.customers.FirstOrDefault(c => c.Id == customerId);
            if (selectedCustomer != null)
            {
                textBox1.Text = selectedCustomer.Id.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                DateTime selectedDate = DateTime.Parse(dateTimePicker1.Text);
                string tür = comboBox1.Text;
                string aciklama = textBox2.Text;
                
                decimal tutar = decimal.Parse(textBox1.Text);

                if (string.IsNullOrWhiteSpace(tür) || string.IsNullOrWhiteSpace(textBox1.Text))

                {
                    throw new Exception("Lütfen zorunlu  alanları doldurunuz.");
                }
                
                OdemeBorc odemeEkle = new OdemeBorc
                {
                    Tarih = selectedDate,
                    Tür = tür,
                    Aciklama = aciklama,
                    Tutar = tutar,
                    musteri_id = customerId.ToString()
                };

               
                odemeList.odemeekle(odemeEkle);

                MessageBox.Show("Ödeme başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string ozelMesaj = "Borç ekleme Sırasında Bir Hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
