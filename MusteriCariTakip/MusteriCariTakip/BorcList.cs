using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusteriCariTakip
{
    class BorcList
    {
        public List<OdemeBorc> borc { get; set; }

        public void borcekle(OdemeBorc borc)
        {
            using (SqlConnection con = Database.GetConnection())
                try
                {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO borclar (tarih, tür, tutar, aciklama,  musteri_id) VALUES (@Tarih, @tür, @Tutar, @Aciklama, @customerId)", con);
                cmd.Parameters.AddWithValue("@Tarih", borc.Tarih);
                cmd.Parameters.AddWithValue("@tür", borc.Tür);
                cmd.Parameters.AddWithValue("@Tutar", borc.Tutar);
                cmd.Parameters.AddWithValue("@Aciklama", borc.Aciklama);
                cmd.Parameters.AddWithValue("@customerId", borc.musteri_id);

                cmd.ExecuteNonQuery();
                con.Close();
                 }
                catch (Exception ex)
                {
                 string ozelMesaj = "Veri Tabanına Borç ekleme işlemi sırasında hata oluştu.";
                 ExceptionLogger.LogException(ex, ozelMesaj);
                 }

            

        }
        public void borcsil(int borcId)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM borclar WHERE id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", borcId);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Borç silme işlemi sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }
            }
        }


    }
}
