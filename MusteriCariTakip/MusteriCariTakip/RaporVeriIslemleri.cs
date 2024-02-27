using System;
using System.Data.SqlClient;

namespace MusteriCariTakip
{
    public class RaporVeriIslemleri
    {
        public string ConnectionString { get; set; }
        private SqlConnection con;

        public RaporVeriIslemleri(string connectionString)
        {
            ConnectionString = connectionString;
            con = new SqlConnection(ConnectionString);
        }

        public (double, double) GetToplamTutarlar(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            double toplamNakit = 0;
            double toplamCek = 0;

            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand kommut = new SqlCommand("SELECT tutar, tür FROM odemeler WHERE tarih BETWEEN @baslangicTarihi AND @bitisTarihi", con);
                kommut.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi);
                kommut.Parameters.AddWithValue("@bitisTarihi", bitisTarihi);

                using (SqlDataReader oku = kommut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        string tur = oku["tür"].ToString();
                        double tutar = Convert.ToDouble(oku["tutar"]);

                        if (tur == "Çek")
                            toplamCek += tutar;
                        else if (tur == "Nakit")
                            toplamNakit += tutar;
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return (toplamNakit, toplamCek);
        }

       
        public (double, double) GetToplamBorc(DateTime baslangicTarihi2, DateTime bitisTarihi2)
        {
            double toplamNakitBorc = 0;
            double toplamCekBorc = 0;

            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand kommut = new SqlCommand("SELECT tutar, tür FROM borclar WHERE tarih BETWEEN @baslangicTarihi AND @bitisTarihi", con);
                kommut.Parameters.AddWithValue("@baslangicTarihi", baslangicTarihi2);
                kommut.Parameters.AddWithValue("@bitisTarihi", bitisTarihi2);

                using (SqlDataReader oku = kommut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        string tur = oku["tür"].ToString();
                        double tutar = Convert.ToDouble(oku["tutar"]);

                        if (tur == "Çek")
                            toplamCekBorc += tutar;
                        else if (tur == "Nakit")
                            toplamNakitBorc += tutar;
                    }
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return (toplamNakitBorc, toplamCekBorc);
        }
    }
}
