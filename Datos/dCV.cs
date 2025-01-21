using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dCV
    {
        private DataBase db = new DataBase();
        public string Insertar(eCV oeCV)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string insert = string.Format("INSERT INTO CV(Oficio,AñosDeExperiencia,NumeroTrabajosAnteriores,Nombre) VALUES ('{0}',{1},{2},'{3}')",oeCV.Oficio,oeCV.AñosDeExperiencia,oeCV.NumeroTrabajosAnteriores,oeCV.Nombre);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Se registró correctamente";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
        public string Eliminar(string Nombre_)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string delete = string.Format("DELETE FROM Cv WHERE Nombre = '{0}'",Nombre_);
                SqlCommand cmd = new SqlCommand(delete,con);
                cmd.ExecuteNonQuery();
                return "el Curriculum viate";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
        public string Modificar(eCV oeCV)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string update = string.Format("UPDATE CV SET Oficio = '{0}',AñosDeExperiencia = {1},NumeroTrabajosAnteriores = {2} WHERE Nombre = '{3}'",oeCV.Oficio,oeCV.AñosDeExperiencia,oeCV.NumeroTrabajosAnteriores,oeCV.Nombre);
                SqlCommand cmd = new SqlCommand(update,con);
                cmd.ExecuteNonQuery();
                return "CV Modificado";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectarDb();
            }
        }
        public string ModificarNombre(string Nombre_)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string update = string.Format("UPDATE CV SET Nombre = '{0}'",Nombre_);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "CV Nombre Modificado";
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
        public List<eCV> ListarTodo()
        {
            try
            {
                List<eCV> lsCV = new List<eCV>();
                eCV oeCV = null;
                SqlConnection con = db.ConectarDb();
                SqlCommand cmd = new SqlCommand("SELECT Oficio,AñosDeExperiencia,NumeroTrabajosAnteriores,Nombre FROM CV", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oeCV = new eCV();
                    oeCV.Oficio = (string)reader["Oficio"];
                    oeCV.AñosDeExperiencia = (int)reader["AñosDeExperiencia"];
                    oeCV.NumeroTrabajosAnteriores = (int)reader["NumeroTrabajosAnteriores"];
                    oeCV.Nombre = (string)reader["Nombre"];
                    lsCV.Add(oeCV);
                }
                reader.Close();
                return lsCV;
            }
            catch(Exception ex)
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
