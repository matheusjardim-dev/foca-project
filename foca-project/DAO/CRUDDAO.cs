using foca_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using foca_project.Views;
using System.Collections;

namespace foca_project.DAO
{
    public class CRUDDAO : ICRUDDAO
    {
        private MySqlConnection _conn;

        public CRUDDAO()
        {
            _conn = Database.GetConnection();
            _conn.Open();
        }

        public MySqlCommand SelectByProperties(string table, string[] properties)
        {
            string query = "SELECT " + properties + " FROM " + table;


            throw new NotImplementedException();
        }

        public MySqlCommand SelectAll(string table)
        {
            string query = "SELECT * FROM " + table;

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            return cmd;
        }

        public MySqlCommand SelectById(string table, string[] where)
        {
            string query = "SELECT * FROM " + table + " WHERE " + where;

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            return cmd;
        }

        public MySqlCommand Create(string table, string[] properties, string[] values)
        {
            string columns = string.Join(", ", properties);
            string valuePlaceholders = string.Join(", ", Enumerable.Repeat("?", values.Length));

            string query = $"INSERT INTO {table} ({columns}) VALUES ({valuePlaceholders})";

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            for (int i = 0; i < values.Length; i++)
            {
                cmd.Parameters.AddWithValue($"@param{i}", values[i]);
            }

            return cmd;
        }

        public MySqlCommand Update(string table, string[] properties, string[] values, string[] where)
        {
            string query = "UPDATE " + table + " SET " + properties + " = " + values + " WHERE " + where;

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            return cmd;
        }

        public MySqlCommand Delete(string table, string[] where)
        {
            string query = "DELETE FROM " + table + " WHERE " + where;

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            return cmd; 
        }

        public MySqlCommand GetActivitiesByUser(int iduser)
        {
            string query = "SELECT tasks.*, category.title as category " +
                "FROM tasks " +
                "INNER JOIN category ON tasks.category_idcategory = idcategory " +
                "WHERE users_idusers = " + iduser + " ORDER BY category_idcategory ASC";

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            return cmd;
        }

        public MySqlCommand Login(string email, string password)
        {
            string query = "SELECT * FROM users WHERE email = '" + email + "' AND password = '" + password + "'";

            MySqlCommand cmd = new MySqlCommand(query, _conn);

            return cmd;
        }
    }
}
