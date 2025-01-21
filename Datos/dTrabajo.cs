using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades; // <-
using System.Data.SqlClient; // <-

namespace Datos
{
    public class dTrabajo
    {
        DataBase db = new DataBase();
        public string Insertar(eTrabajo oeTrabajo)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string insert = string.Format("INSERT INTO Trabajo(Area,AñosDeExperiencia,Sueldo,LugarEmpleo,NumeroVacantes,IDempresa) VALUES ('{0}',{1},{2},'{3}','{4}','{5}')", oeTrabajo.Area, oeTrabajo.AñosDeExperiencia, oeTrabajo.Sueldo, oeTrabajo.LugarDeEmpleo, oeTrabajo.NumeroDeVacantes, oeTrabajo.Empresa.idEmpresa);
                SqlCommand cmd = new SqlCommand(insert,con);
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
        public string Eliminar(int IDTrabajo_)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string delete = string.Format("DELETE FROM Trabajo WHERE IDtrabajo = {0}",IDTrabajo_);
                SqlCommand cmd = new SqlCommand(delete,con);
                cmd.ExecuteNonQuery();
                return "Se eliminó correctamente";
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
        public string Modificar(eTrabajo oeTrabajo)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string update = string.Format("UPDATE  Trabajo SET Area = '{0}',AñosDeExperiencia = {1},Sueldo = {2} ,LugarEmpleo = '{3}' ,NumeroVacantes = {4}, IDempresa = {5} WHERE IDTrabajo = {6}", oeTrabajo.Area, oeTrabajo.AñosDeExperiencia, oeTrabajo.Sueldo, oeTrabajo.LugarDeEmpleo, oeTrabajo.NumeroDeVacantes, oeTrabajo.Empresa.idEmpresa, oeTrabajo.IDtrabajo);
                SqlCommand cmd = new SqlCommand(update,con);
                cmd.ExecuteNonQuery();
                return "Modificado correctamente";
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
        public List<eTrabajo> ListarTodo()
        {
            try
            {
                List<eTrabajo> lsTrabajo = new List<eTrabajo>();
                eTrabajo oeTrabajo = null;
                eEmpresa oeEmpresa = null;
                SqlConnection con = db.ConectarDb();
                SqlCommand cmd = new SqlCommand("SELECT trab.Area,trab.AñosDeExperiencia,trab.Sueldo,trab.LugarEmpleo,trab.NumeroVacantes,trab.IDtrabajo, em.Nombre as Empresa, em.IDEmpresa FROM Empresa as em, Trabajo as trab WHERE trab.IDempresa = em.IDEmpresa",con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oeTrabajo = new eTrabajo();
                    oeEmpresa = new eEmpresa();
                    oeTrabajo.Area = (string)reader["Area"];
                    oeTrabajo.AñosDeExperiencia = (int)reader["AñosDeExperiencia"];
                    oeTrabajo.Sueldo = (decimal)reader["Sueldo"];
                    oeTrabajo.LugarDeEmpleo = (string)reader["LugarEmpleo"];
                    oeTrabajo.NumeroDeVacantes = (int)reader["NumeroVacantes"];
                    oeTrabajo.IDtrabajo = (int)reader["IDtrabajo"];

                    oeEmpresa.NombreEmpresa = (string)reader["Empresa"];
                    oeTrabajo.Empresa = oeEmpresa;
                                                
                    lsTrabajo.Add(oeTrabajo);
                }
                reader.Close();
                return lsTrabajo;
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
