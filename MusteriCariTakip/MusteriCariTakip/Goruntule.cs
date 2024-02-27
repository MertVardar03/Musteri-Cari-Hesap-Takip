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

    public partial class Goruntule : Form

    {
        private Customer selectedCustomer; 



        
        OdemeBorcList odemeborclistesi = new OdemeBorcList();
        OdemeBorcList odemeborclistesi2 = new OdemeBorcList();
        public Goruntule(Customer selectedCustomer)
        {
            InitializeComponent();
            this.selectedCustomer = selectedCustomer; // seçili müşteriyi al
            Goruntule_Load(); 
           
        }

        
        private void Goruntule_Load()
        {
            if (selectedCustomer != null)
            {
                label10.Text = selectedCustomer.Ad;
                label11.Text = selectedCustomer.Soyad;
                label12.Text = selectedCustomer.Firma_ismi;
                label13.Text = selectedCustomer.Telefon;
                label14.Text = selectedCustomer.Adres;

                

                GetOdemeForCustomer(selectedCustomer.Id);
                GetBorcForCustomer(selectedCustomer.Id);

                dataGridView2.DataSource = odemeborclistesi.odemeborc;

                dataGridView1.DataSource = odemeborclistesi2.odemeborc;
                dataGridView2.Columns["musteri_id"].Visible = false;
                dataGridView1.Columns["musteri_id"].Visible = false;
                decimal toplamOdeme = odemeborclistesi.ToplamOdeme(selectedCustomer.Id);
                label16.Text = toplamOdeme.ToString()+"TL";
                decimal toplamBorc2 = odemeborclistesi2.ToplamBorc(selectedCustomer.Id);
                label15.Text = toplamBorc2.ToString()+"TL";
                decimal kalanBorc = toplamOdeme - toplamBorc2;//bana 20 tl borç yaptı 10 tl ödeme yaptı genel toplam -10
                label17.Text =  kalanBorc.ToString()+"TL";
            }
           

            int columnIndex = dataGridView1.Columns["İşlem"].Index;
            dataGridView1.Columns["İşlem"].DisplayIndex = dataGridView1.ColumnCount - 1;

            int columnIndex1 = dataGridView2.Columns["İşlem2"].Index;
            dataGridView2.Columns["İşlem2"].DisplayIndex = dataGridView2.ColumnCount - 1;
           
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);


            dataGridView2.CellContentClick += new DataGridViewCellEventHandler(dataGridView2_CellContentClick);

          
        }

        private void GetOdemeForCustomer(int customerId)
        {
            odemeborclistesi.GetOdemeForCustomer(customerId);
        }private void GetBorcForCustomer(int customerId)
        {
            odemeborclistesi2.GetBorcForCustomer(customerId);
        }

        private void Goruntule_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["İşlem"].Index && e.RowIndex >= 0)
            {
                int borcId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                DialogResult result = MessageBox.Show("Bu borcu silmek istediğinize emin misiniz?", "Borç Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    BorcList borcList = new BorcList();
                    borcList.borcsil(borcId); 

                    this.Close(); 
                    Goruntule form = new Goruntule(selectedCustomer);
                    form.Show(); 
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["İşlem2"].Index && e.RowIndex >= 0)
            {
                int odemeId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["Id"].Value);

                DialogResult result = MessageBox.Show("Bu Ödemeyi silmek istediğinize emin misiniz?", "Ödeme Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    OdemeList odemeList = new OdemeList();
                    odemeList.odemecsil(odemeId); 

                    this.Close(); 
                    Goruntule form = new Goruntule(selectedCustomer);
                    form.Show(); 
                }
            }
        }


    }
}
