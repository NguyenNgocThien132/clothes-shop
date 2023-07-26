using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_KhachHang : DbConnect
    {
        // Danh sách khách hàng
        public DataTable ListOfCustomers()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ListOfCustomers";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }
        // Thêm khách hàng
        public bool InsertCustomer(DTO_KhachHang customer)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertCustomer";
                cmd.Parameters.AddWithValue("Name", customer.Name);
                cmd.Parameters.AddWithValue("Address", customer.Address);
                cmd.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Cập nhật thông tin khách hàng
        public bool UpdateCustomer(DTO_KhachHang customer)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCustomer";
                cmd.Parameters.AddWithValue("Id", customer.Id);
                cmd.Parameters.AddWithValue("Name", customer.Name);
                cmd.Parameters.AddWithValue("Address", customer.Address);
                cmd.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Xóa khách hàng
        public bool DeleteCustomer(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteCustomer";
                cmd.Parameters.AddWithValue("id", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Tìm kiếm khách hàng có trong bảng Customer
        public DataTable SearchCustomer(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchCustomer";
                cmd.Parameters.AddWithValue("name", name);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }
        // Danh sách khách hàng lấy theo trường ID, Name
        public string[] ListCustomerIdName()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ListCustomerIdName";
                List<string> list = new List<string>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
                return list.ToArray();
            }
            finally
            {
                _conn.Close();
            }
        }
        ////Lấy ID khách hàng
        //public int GetCustumerId(string name)
        //{
        //    try
        //    {
        //        _conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = _conn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetCustumerId";
        //        cmd.Parameters.AddWithValue("name", name);
        //        return Convert.ToInt32(cmd.ExecuteScalar());
        //    }
        //    finally
        //    {
        //        _conn.Close();
        //    }
        //}
    }
}
