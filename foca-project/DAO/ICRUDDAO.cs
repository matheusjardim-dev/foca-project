using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foca_project.DAO
{
    internal interface ICRUDDAO
    {
        MySqlCommand SelectByProperties(string table, string[] propeties);

        MySqlCommand SelectAll(string table);

        MySqlCommand Create(string table, string[] propeties, string[] values);

        MySqlCommand Update(string table, string[] propeties, string[] values, string[] where);

        MySqlCommand Delete(string table, string[] where);

        MySqlCommand GetActivitiesByDirectory(int idDirectory);

        MySqlCommand Login(string email, string password);
    }
}
