using DataAccess.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DataAccess.Concrete.AdoNet
{
    public class UserDal : IUserDal
    {
        public void Add(User user)
        {
            var cs = "Host=localhost;Username=postgres;Password=fikret0108;Database=UserRegistrationDb";
            var con = new NpgsqlConnection(cs);
            con.Open();
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "public.add_user";
                cmd.Parameters.AddWithValue("firstname", user.FirstName);
                cmd.Parameters.AddWithValue("lastname",user.LastName);
                cmd.Parameters.AddWithValue("email",user.Email);
                cmd.Parameters.AddWithValue("password",user.Password);
                cmd.ExecuteScalar();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception(ex.Message);
            }

             
        }

        public void Delete(User user)
        {
            var cs = "Host=localhost;Username=postgres;Password=fikret0108;Database=UserRegistrationDb";
            var con = new NpgsqlConnection(cs);
            con.Open();
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "public.delete_user";
                cmd.Parameters.AddWithValue("_id", user.Id);
                cmd.ExecuteScalar();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception(ex.Message);
            }

        }

        public List<User> GetAll()
        {
            var cs = "Host=localhost;Username=postgres;Password=fikret0108;Database=UserRegistrationDb";
            var con = new NpgsqlConnection(cs);
            con.Open();

            List<User> users = new List<User>();
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "public.get_all_users";
                var rdr = cmd.ExecuteScalar();
                 
                users = JsonConvert.DeserializeObject<List<User>>(rdr.ToString());
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception(ex.Message);
            }

            return users;

        }

        public User GetById(int id)
        {
            var cs = "Host=localhost;Username=postgres;Password=fikret0108;Database=UserRegistrationDb";
            var con = new NpgsqlConnection(cs);
            con.Open();
            User user;
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "public.get_by_id";
                cmd.Parameters.AddWithValue("value", id);
                var rdr = cmd.ExecuteScalar();
                user = JsonConvert.DeserializeObject<User>(rdr.ToString());
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception(ex.Message);
            }

            return user;
        }

        public void Update(User user)
        {
            var cs = "Host=localhost;Username=postgres;Password=fikret0108;Database=UserRegistrationDb";
            var con = new NpgsqlConnection(cs);
            con.Open();
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "public.update_user";
                cmd.Parameters.AddWithValue("_id", user.Id);
                cmd.Parameters.AddWithValue("_firstname", user.FirstName);
                cmd.Parameters.AddWithValue("_lastname", user.LastName);
                cmd.Parameters.AddWithValue("_email", user.Email);
                cmd.Parameters.AddWithValue("_password", user.Password);
                cmd.ExecuteScalar();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception(ex.Message);
            }
        }
    }
}
