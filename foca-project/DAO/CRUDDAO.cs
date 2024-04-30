﻿using foca_project.Models;
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

        public MySqlCommand Create(string table, string[] properties, string[] values)
        {
            string query = "INSERT INTO " + table + " (" + properties + ") VALUES (" + values + ")";

            MySqlCommand cmd = new MySqlCommand(query, _conn);

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
    }
}
