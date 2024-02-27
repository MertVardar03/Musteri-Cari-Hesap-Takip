using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MusteriCariTakip
{
    
    public class CustomerList
    {
        public List<Customer> customers { get; set; }
      
        public CustomerList()
        {
            customers = new List<Customer>();
            GetCustomers();
        }

        private void GetCustomers()
        {
            using (SqlConnection con = Database.GetConnection())
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM musteriler", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        
                        Customer customer = new Customer();

                        customer.Id = Convert.ToInt32(dr[0]);
                        customer.Ad = dr[1].ToString();
                        customer.Soyad = dr[2].ToString();
                        customer.Firma_ismi = dr[3].ToString();
                        customer.Adres = dr[4].ToString();
                        customer.Telefon = dr[5].ToString();

                        customers.Add(customer);

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

        

        public void addCustomer(Customer customer)
        {
            using (SqlConnection con = Database.GetConnection())
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO musteriler (ad, soyad, firma_ismi, adres, telefon) VALUES (@Ad, @Soyad, @FirmaIsmi,@Adres, @Telefon)", con);
                    cmd.Parameters.AddWithValue("@Ad", customer.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", customer.Soyad);
                    cmd.Parameters.AddWithValue("@FirmaIsmi", customer.Firma_ismi);
                    cmd.Parameters.AddWithValue("@Adres", customer.Adres);
                    cmd.Parameters.AddWithValue("@Telefon", customer.Telefon);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ozelMesaj = "Veri Tabanına müşteri ekleme sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }

        }

        

        public void UpdateCustomer(Customer updatedCustomer)
        {
            using (SqlConnection con = Database.GetConnection())
                try 
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE musteriler SET ad = @Ad, soyad = @Soyad, firma_ismi = @FirmaIsmi, adres = @Adres, telefon = @Telefon WHERE musteri_id = @CustomerId", con);
                    cmd.Parameters.AddWithValue("@Ad", updatedCustomer.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", updatedCustomer.Soyad);
                    cmd.Parameters.AddWithValue("@FirmaIsmi", updatedCustomer.Firma_ismi);
                    cmd.Parameters.AddWithValue("@Adres", updatedCustomer.Adres);
                    cmd.Parameters.AddWithValue("@Telefon", updatedCustomer.Telefon);
                    cmd.Parameters.AddWithValue("@CustomerId", updatedCustomer.Id);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                 catch (Exception ex)
                {
                    string ozelMesaj = "Veri Tabanında müşteri Düzenleme sırasında hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }

        }

        public void DeleteCustomer(Customer deleteCustomer)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM musteriler WHERE musteri_id = @CustomerId", con);
                    cmd.Parameters.AddWithValue("@CustomerId", deleteCustomer.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                       
                        Customer customerToRemove = customers.FirstOrDefault(c => c.Id == deleteCustomer.Id);
                        if (customerToRemove != null)
                        {
                            customers.Remove(customerToRemove);
                        }
                    }
                    else
                    {
                        throw new Exception("Lütfen Zorunlu alanları doldurunuz.");
                        
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lütfen Önce Müşteriye Ait Ödeme Ve Borçları silin");
                    string ozelMesaj = "Veritabanından müşteri silme sırasında bir hata oluştu.";
                    ExceptionLogger.LogException(ex, ozelMesaj);
                }
            }
        }

    }





}
