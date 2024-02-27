using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MusteriCariTakip
{
    public partial class Raporlar : Form
    {
        private RaporVeriIslemleri veriIslemleri;

        public Raporlar()
        {
            InitializeComponent();

            dateTimePicker1.ValueChanged += DateTimePickerValueChanged;
            dateTimePicker2.ValueChanged += DateTimePickerValueChanged;

            dateTimePicker3.ValueChanged += DateTimePickerValueChanged2;
            dateTimePicker4.ValueChanged += DateTimePickerValueChanged2;

           
            string connectionString = Database.GetConnection().ConnectionString;

            veriIslemleri = new RaporVeriIslemleri(connectionString);
            veriIslemleri.ConnectionString = connectionString;
        }

        private void DateTimePickerValueChanged(object sender, EventArgs e)
        {
            
            RaporlarıYenile();
        }

        private void DateTimePickerValueChanged2(object sender, EventArgs e)
        {
          
            RaporlarıYenile2();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            RaporlarıYenile();
            RaporlarıYenile2();
           
        }
        private void RaporlarıYenile()
        {
            DateTime baslangicTarihi = dateTimePicker1.Value;
            DateTime bitisTarihi = dateTimePicker2.Value;

            try
            {
                (double toplamNakit, double toplamCek) = veriIslemleri.GetToplamTutarlar(baslangicTarihi, bitisTarihi);

               
                
                chart1.Series.Clear();
                chart1.Series.Add("ToplamTutarlar");
                chart1.Series["ToplamTutarlar"].Points.AddXY("Toplam Nakit", toplamNakit);
                chart1.Series["ToplamTutarlar"].Points.AddXY("Toplam Çek", toplamCek);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void RaporlarıYenile2()
        {
            DateTime baslangicTarihi2 = dateTimePicker3.Value;
            DateTime bitisTarihi2 = dateTimePicker4.Value;

            try
            {
                (double toplamNakitBorc, double toplamCekBorc) = veriIslemleri.GetToplamBorc(baslangicTarihi2, bitisTarihi2);

               

                chart2.Series.Clear();
                chart2.Series.Add("ToplamTutarlar");
                chart2.Series["ToplamTutarlar"].Points.AddXY("Toplam Nakit", toplamNakitBorc);
                chart2.Series["ToplamTutarlar"].Points.AddXY("Toplam Çek", toplamCekBorc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
