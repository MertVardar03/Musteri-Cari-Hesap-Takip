using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace MusteriCariTakip
{
    public static class ExceptionLogger
    {
        public static List<Log> logs { get; set; } = new List<Log>();


        public static void GetLog()
        {
            logs.Clear(); 
            using (SqlConnection con = Database.GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM LogTablosu", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Log log = new Log();
                        log.Id = Convert.ToInt32(dr["Id"]);
                        log.OzelMesaj = dr["ozelMesaj"].ToString();
                        log.HataMesaji = dr["hataMesaji"].ToString();
                        log.HataStackTrace = dr["hataStackTrace"].ToString();
                        log.KullaniciAdi = dr["kullaniciAdi"].ToString();
                        log.Tarih = Convert.ToDateTime(dr["tarih"]);
                        logs.Add(log);
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Müşteri Listeleme sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }
            }
        }
        public static void LogException(Exception hata, string ozelMesaj)
        {


            try
            {
                string logContent = $"Özel Mesaj: {ozelMesaj}\nHata Mesajı: {hata.Message}\nHata Stack Trace: {hata.StackTrace}\n";

                using (SqlConnection connection = Database.GetConnection())
                {
                    connection.Open();

                    string sqlQuery = "INSERT INTO LogTablosu (ozelMesaj, hataMesaji, hataStackTrace, kullaniciAdi, tarih) " +
                        "VALUES (@ozelMesaj, @hataMesaji, @hataStackTrace, @kullaniciAdi, @tarih)";

                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
                    sqlCommand.Parameters.AddWithValue("@ozelMesaj", ozelMesaj);
                    sqlCommand.Parameters.AddWithValue("@hataMesaji", hata.Message);
                    sqlCommand.Parameters.AddWithValue("@hataStackTrace", hata.StackTrace);
                    sqlCommand.Parameters.AddWithValue("@kullaniciAdi", Environment.UserName);
                    sqlCommand.Parameters.AddWithValue("@tarih", DateTime.Now);

                    sqlCommand.ExecuteNonQuery();
                }

                string logFilePath = "log.txt";
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("\r\n@");
                    sw.WriteLine(Environment.UserName);
                    sw.WriteLine("@");
                    sw.WriteLine(hata.StackTrace);
                    sw.WriteLine("@");
                    sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    sw.WriteLine("@");
                    sw.WriteLine(logContent);
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loglama hatası: {ex.Message}");
               
            }




        }
    }
}
