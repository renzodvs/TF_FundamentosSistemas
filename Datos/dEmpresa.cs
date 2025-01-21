using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades; // <-
using System.Data.SqlClient; // <-

namespace Datos
{
    public class dEmpresa
    {
        DataBase db = new DataBase();
        public string Insertar(eEmpresa oeEmpresa)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string insert = string.Format("INSERT INTO Empresa(Nombre) VALUES ('{0}')", oeEmpresa.NombreEmpresa);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Se registró correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
        public string Eliminar(int IDEmpresa_)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string delete = string.Format("DELETE FROM Empresa WHERE IDEmpresa = {0}", IDEmpresa_);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Se eliminó correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
        public string Modificar(eEmpresa oeEmpresa)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string update = string.Format("UPDATE  Empresa SET Nombre = '{0}'WHERE IDEmpresa = {1}", oeEmpresa.NombreEmpresa, oeEmpresa.idEmpresa);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
        public List<eEmpresa> ListarTodo()
        {
            try
            {
                List<eEmpresa> lsEmpresa = new List<eEmpresa>();
                eEmpresa oeEmpresa = null;
                SqlConnection con = db.ConectarDb();
                SqlCommand cmd = new SqlCommand("SELECT Nombre,IDEmpresa FROM Empresa", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oeEmpresa = new eEmpresa();
                    oeEmpresa.NombreEmpresa = (string)reader["Nombre"];
                    oeEmpresa.idEmpresa = (int)reader["IDEmpresa"];
                    lsEmpresa.Add(oeEmpresa);
                }
                reader.Close();
                return lsEmpresa;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
    }
}
