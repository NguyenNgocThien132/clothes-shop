﻿using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DbConnect
    {
        // Kết nối database
        static string connstr = ConfigurationManager.ConnectionStrings["ShopQuanAo"].ToString();
        protected SqlConnection _conn = new SqlConnection(connstr);
    }
}
