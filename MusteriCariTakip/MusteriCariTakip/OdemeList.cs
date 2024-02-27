using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace MusteriCariTakip
{
    class OdemeList
    {
        public List<OdemeBorc> odeme { get; set; }

        public void odemeekle(OdemeBorc odeme)
        {
            using (SqlConnection con = Database.GetConnection())
                try {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO odemeler (tarih, tür, tutar, aciklama,  musteri_id) VALUES (@Tarih, @tür, @Tutar, @Aciklama, @customerId)", con);
                cmd.Parameters.AddWithValue("@Tarih", odeme.Tarih);
                cmd.Parameters.AddWithValue("@tür", odeme.Tür);
                cmd.Parameters.AddWithValue("@Tutar", odeme.Tutar);
                cmd.Parameters.AddWithValue("@Aciklama", odeme.Aciklama);
                cmd.Parameters.AddWithValue("@customerId", odeme.musteri_id);

                cmd.ExecuteNonQuery();
                con.Close(); 
                 }
           
            catch (Exception ex)
            {
                string ozelMesaj = "Ödeme ekleme işlemi sırasında hata oluştu.";
                ExceptionLogger.LogException(ex, ozelMesaj);
            }
        }

        public void odemecsil(int odemeId)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM odemeler WHERE id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", odemeId);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Odeme silme işlemi sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }
            }
        }



    }
}
