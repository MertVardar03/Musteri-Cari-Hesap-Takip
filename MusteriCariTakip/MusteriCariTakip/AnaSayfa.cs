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
    public partial class AnaSayfa : Form
    {
        public void YenileAnaForm()
        {
            
            musteriListesi = new CustomerList();

           
            dgvCustomers.DataSource = musteriListesi.customers;

            
        }
        public void YetkiKontrol(string yetki)
        {
            
            if (yetki == "admin")
            {
                
                button1.Visible = true;
                button3.Visible = true;
                
            }
            else
            {
                
                button1.Enabled = false;
                button3.Enabled = false;

            }

        }
       
        public AnaSayfa()
        {
            InitializeComponent();
            
        }

        CustomerList musteriListesi = new CustomerList();
        
        private void AnaSayfa_Load(object sender, EventArgs e)

        {
            
           
            dgvCustomers.DataSource = musteriListesi.customers;

            
            //butonları en son column'a götürüyor
            int columnIndex = dgvCustomers.Columns["ColumnGoruntule"].Index;
            dgvCustomers.Columns["ColumnGoruntule"].DisplayIndex = dgvCustomers.ColumnCount - 1;

            int columnIndex1 = dgvCustomers.Columns["ColumnBorcEkle"].Index;
            dgvCustomers.Columns["ColumnBorcEkle"].DisplayIndex = dgvCustomers.ColumnCount - 1;

            int columnIndex2 = dgvCustomers.Columns["ColumnOdemeEkle"].Index;
            dgvCustomers.Columns["ColumnOdemeEkle"].DisplayIndex = dgvCustomers.ColumnCount - 1;

            int columnIndex3 = dgvCustomers.Columns["ColumnMusteriDuzenle"].Index;
            dgvCustomers.Columns["ColumnMusteriDuzenle"].DisplayIndex = dgvCustomers.ColumnCount - 1;

            int columnIndex4 = dgvCustomers.Columns["ColumnMusteriSil"].Index;
            dgvCustomers.Columns["ColumnMusteriSil"].DisplayIndex = dgvCustomers.ColumnCount - 1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriEkle musteriEkle = new MusteriEkle(this);
            musteriEkle.Show();
            
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                if (dgvCustomers.Columns[e.ColumnIndex].Name == "ColumnBorcEkle")
                {

                    int selectedCustomerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value);
                    
                    BorcEkle duzenle = new BorcEkle(selectedCustomerId);
                    duzenle.Show();
                    

                }
            }
          

            //Ödeme ekleme form açma
            if (e.RowIndex >=0 && e.ColumnIndex >= 0)
            {

                if (dgvCustomers.Columns[e.ColumnIndex].Name == "ColumnOdemeEkle")
                {

                    int selectedCustomerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value);
                    
                    OdemeEkle duzenle = new OdemeEkle(selectedCustomerId);
                    duzenle.Show();
                    

                }
            }

            //Görüntüleme form açma
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvCustomers.Columns[e.ColumnIndex].Name == "ColumnGoruntule") { 
                    
                    int seciliMusteriId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value);

            
                Customer selectedCustomer = musteriListesi.customers.FirstOrDefault(c => c.Id == seciliMusteriId);
                if (selectedCustomer != null)
                {   
                    Goruntule goruntule = new Goruntule(selectedCustomer);
                    goruntule.Show();
                }
                else
                {
                    MessageBox.Show("Müşteri bulunamadı.");
                }

                }

            }

            //Müşteri Düzenle form açma
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvCustomers.Columns[e.ColumnIndex].Name == "ColumnMusteriDuzenle")
                {

                    int selectedCustomerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value);
                    
                    MusteriDuzenle duzenle = new MusteriDuzenle(selectedCustomerId, this);
                    duzenle.Show();
                 

                }

            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvCustomers.Columns[e.ColumnIndex].Name == "ColumnMusteriSil")
                {
                    DataGridViewRow selectedRow = dgvCustomers.Rows[e.RowIndex];
                    if (selectedRow != null)
                    {
                        Customer selectedCustomer = selectedRow.DataBoundItem as Customer;

                        DialogResult result = MessageBox.Show("Müşteriyi silmek istediğinizden emin misiniz?", "Müşteri Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                       
                        if (result == DialogResult.Yes)
                        {
                           
                            musteriListesi.DeleteCustomer(selectedCustomer);

                           
                            dgvCustomers.DataSource = null;
                            dgvCustomers.DataSource = musteriListesi.customers;

                            dgvCustomers.Columns["ColumnGoruntule"].DisplayIndex = dgvCustomers.ColumnCount - 1;
                            dgvCustomers.Columns["ColumnBorcEkle"].DisplayIndex = dgvCustomers.ColumnCount - 1;
                            dgvCustomers.Columns["ColumnOdemeEkle"].DisplayIndex = dgvCustomers.ColumnCount - 1;
                            dgvCustomers.Columns["ColumnMusteriDuzenle"].DisplayIndex = dgvCustomers.ColumnCount - 1;
                            dgvCustomers.Columns["ColumnMusteriSil"].DisplayIndex = dgvCustomers.ColumnCount - 1;
                        }
                    }
                }
            }




        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            musteriListesi = new CustomerList();

          
            dgvCustomers.DataSource = musteriListesi.customers;

            MessageBox.Show("Veriler başarıyla yenilendi.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Raporlar raporlar = new Raporlar();
            raporlar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
        }
    }
}
