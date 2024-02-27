using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriCariTakip
{
    class Database
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=DESKTOP-DPQ430G\SQLEXPRESS;Initial Catalog=MusteriCariDB;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
