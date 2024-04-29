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
    }
}
