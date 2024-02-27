using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MusteriCariTakip
{
    class OdemeBorcList
    {
        public List<OdemeBorc> odemeborc { get; set; }

        public OdemeBorcList()
        {
            odemeborc = new List<OdemeBorc>();
           
        }
        public void GetOdemeForCustomer(int customerId)
        {
            using(SqlConnection con = Database.GetConnection())
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM odemeler WHERE musteri_id = @customerId", con);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    SqlDataReader dr = cmd.ExecuteReader();




                    while (dr.Read())
                    {
                       
                        OdemeBorc odeme = new OdemeBorc();
                        odeme.Id = Convert.ToInt32(dr["id"]);
                        odeme.musteri_id = dr["musteri_id"].ToString();
                        odeme.Aciklama = dr["Aciklama"].ToString();
                        odeme.Tür = dr["tür"].ToString();
                        odeme.Tutar =Convert.ToInt32(dr["Tutar"]) ;
                        odeme.Tarih = Convert.ToDateTime(dr["tarih"]);



                        odemeborc.Add(odeme);
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Ödemeleri Listeleme Sırasında Bir Hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }

        }
        public void GetBorcForCustomer(int customerId)
        {
            using (SqlConnection con = Database.GetConnection())
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM borclar WHERE musteri_id = @customerId", con);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        OdemeBorc borc = new OdemeBorc();
                        borc.Id = Convert.ToInt32(dr["id"]);
                        borc.musteri_id = dr["musteri_id"].ToString();
                        borc.Aciklama = dr["Aciklama"].ToString();
                        borc.Tür = dr["tür"].ToString();
                        borc.Tutar = Convert.ToInt32(dr["Tutar"]);
                        borc.Tarih = Convert.ToDateTime(dr["tarih"]);

                        odemeborc.Add(borc);
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Borçları Listeleme Sırasında Bir Hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }

        }
        public decimal ToplamOdeme(int customerId)
        {
            decimal toplamOdeme = 0;
            odemeborc.ForEach(odemeborc =>
            {
                if (odemeborc.musteri_id == customerId.ToString())
                {
                    toplamOdeme += odemeborc.Tutar; 
                }
            });
            return toplamOdeme;
        }
        public decimal ToplamBorc(int customerId)
        {
            decimal toplamBorc = 0;
            odemeborc.ForEach(odemeborc =>
            {
                if (odemeborc.musteri_id == customerId.ToString())
                {
                    toplamBorc += odemeborc.Tutar; 
                }
            });
            return toplamBorc;
        }
    }

}
