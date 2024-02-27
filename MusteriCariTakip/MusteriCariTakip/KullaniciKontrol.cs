using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriCariTakip
{
    class KullaniciKontrol
    {
        public string KullaniciDogrula(Kullanici kullanici)
        {
            try
            {
                using (SqlConnection con = Database.GetConnection())
                {
                    string query = "SELECT yetki FROM kullanicilar WHERE kullanici_adi = @kullanici_adi AND sifre = @sifre";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@kullanici_adi", kullanici.kullanici_adi);
                    command.Parameters.AddWithValue("@sifre", kullanici.sifre);

                    con.Open();
                    string yetki = (string)command.ExecuteScalar();
                    con.Close();

                    return yetki; // Kullanıcının yetki bilgisini döndür
                }
            }
            catch (Exception ex)
            {
                
                string ozelMesaj = "Kullanıcı Listeleme sırasında hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
                
                return null; 
            }
        }

        public List<Kullanici> kullanicilar { get; set; }
        


        
        public KullaniciKontrol()
        {
            
            kullanicilar = new List<Kullanici>();
            GetKullanici();
        }
        private void GetKullanici()
        {
            using (SqlConnection con = Database.GetConnection())
                try {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM kullanicilar", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        Kullanici kullanici = new Kullanici();

                        kullanici.Id = Convert.ToInt32(dr[0]);
                        kullanici.kullanici_adi = dr[1].ToString();
                        kullanici.sifre = dr[2].ToString();
                        kullanici.yetki = dr[3].ToString();


                        kullanicilar.Add(kullanici);

                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    
                    string ozelMesaj = "Kullanıcı Listeleme sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }


        }
        public void addKullanici(Kullanici kullanicilar)
        {
            using (SqlConnection con = Database.GetConnection())
                try {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO kullanicilar (kullanici_adi, sifre, yetki) VALUES (@kullanici_adi, @sifre, @yetki)", con);

                    cmd.Parameters.AddWithValue("@kullanici_adi", kullanicilar.kullanici_adi);
                    cmd.Parameters.AddWithValue("@sifre", kullanicilar.sifre);
                    cmd.Parameters.AddWithValue("@yetki", kullanicilar.yetki);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Kullanıcı Ekleme sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }

        }

        public void UpdateKullanici(Kullanici kullanicilar)
        {
            using (SqlConnection con = Database.GetConnection())
                try {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE kullanicilar SET kullanici_adi = @kullanici_adi, sifre = @sifre, yetki = @yetki WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@kullanici_adi", kullanicilar.kullanici_adi);
                    cmd.Parameters.AddWithValue("@sifre", kullanicilar.sifre);
                    cmd.Parameters.AddWithValue("@yetki", kullanicilar.yetki);
                    cmd.Parameters.AddWithValue("@Id", kullanicilar.Id);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Kullanıcı Güncelleme sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }

        }
    }
}
