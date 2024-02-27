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
    public partial class Ayarlar : Form
    {

        KullaniciKontrol kullanici = new KullaniciKontrol();
       
        
        
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =kullanici.kullanicilar;
            
            int columnIndex = dataGridView1.Columns["ColumnAktar"].Index;
            dataGridView1.Columns["ColumnAktar"].DisplayIndex = dataGridView1.ColumnCount - 1;
         
            dataGridView1.CellClick += DataGridView1_CellClick;

            ExceptionLogger.GetLog(); 
            dataGridView2.DataSource = ExceptionLogger.logs;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Eğer seçilen satır varsa devam et
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                
                textBox1.Text = selectedRow.Cells["Id"].Value.ToString();
                textBox2.Text = selectedRow.Cells["kullanici_adi"].Value.ToString();
                textBox3.Text = selectedRow.Cells["sifre"].Value.ToString(); 
                comboBox1.Text = selectedRow.Cells["yetki"].Value.ToString();
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   try {
                string kullaniciadi = textBox2.Text;
                string sifre = textBox3.Text;
                string yetki = comboBox1.Text;

                if(!string.IsNullOrWhiteSpace(kullaniciadi) && !string.IsNullOrWhiteSpace(sifre) &&
                     !string.IsNullOrWhiteSpace(yetki))

                {
                   
                    Kullanici addkullanici = new Kullanici
                    {
                        kullanici_adi = kullaniciadi,
                        sifre = sifre,
                        yetki = yetki,


                    };

                    kullanici.addKullanici(addkullanici);
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                    this.Close();
                    Ayarlar form = new Ayarlar();
                    form.Show(); 
                }
                else
                {
                    throw new Exception("Lütfen zorunlu  alanları doldurunuz.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string ozelMesaj = "Kullanıcı ekleme Sırasında Bir Hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int parsedId;

                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                    !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                    int.TryParse(textBox1.Text, out parsedId))
                {
                    Kullanici updatekullanici = new Kullanici
                    {
                        Id = parsedId,
                        kullanici_adi = textBox2.Text,
                        sifre = textBox3.Text,
                        yetki = comboBox1.Text,
                    };

                    kullanici.UpdateKullanici(updatekullanici);
                    MessageBox.Show("Kullanıcı güncellendi.");
                    this.Close(); 
                    Ayarlar form = new Ayarlar();
                    form.Show(); 
                }
                else
                {
                    throw new Exception("Lütfen zorunlu tüm alanları doldurunuz");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                string ozelMesaj = "Kullanıcı güncelleme Sırasında Bir Hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }
        }

    }

}
