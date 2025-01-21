using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // <-

namespace Datos
{
    public class DataBase
    {
        private SqlConnection conn;
        public SqlConnection ConectarDb()
        {
            try
            {
                string CadenaConexion = "Data Source = localhost; Initial Catalog = dbTrabajoFinalFundamentos; Integrated Security = True";
                conn = new SqlConnection(CadenaConexion);
                conn.Open();
                return conn;
            }
            catch(SqlException ex)
            {
                return null;
            }
        }
        public void DesconectarDb()
        {
            conn.Close();
        }
    }
}
