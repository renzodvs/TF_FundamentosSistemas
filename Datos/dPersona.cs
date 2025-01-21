using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dPersona
    {
        private DataBase db = new DataBase();
        public string Insertar(ePersona oePersona)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string insert = string.Format("INSERT INTO Persona(Nombre,Edad,Direccion,IDTrabajo) VALUES ('{0}',{1},'{2}',{3})",oePersona.Nombre,oePersona.Edad,oePersona.Direccion,oePersona.IDtrabajo);
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
        public string Eliminar(int IDPersona_)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string delete = string.Format("DELETE Persona WHERE IDPersona = {0}", IDPersona_);
                SqlCommand cmd = new SqlCommand(delete,con);
                cmd.ExecuteNonQuery();
                return "Se eliminó la Persona y ";
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
        public string Modificar(ePersona oePersona)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string update = string.Format("UPDATE Persona SET Nombre = '{0}',Edad = {1},Direccion = '{2}',IDTrabajo = {3}, WHERE IDPersona = {4}",oePersona.Nombre,oePersona.Edad,oePersona.Direccion,oePersona.IDtrabajo, oePersona.IDPersona);
                SqlCommand cmd = new SqlCommand(update,con);
                cmd.ExecuteNonQuery();
                return "Se modificó";
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
        public List<ePersona> ListarTodo()
        {
            try
            {
                List<ePersona> lsPersonas = new List<ePersona>();
                ePersona oePersona = null;
                SqlConnection con = db.ConectarDb();
                SqlCommand cmd = new SqlCommand("SELECT Nombre,Edad,Direccion,IDTrabajo,IDPersona FROM Persona",con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oePersona = new ePersona();
                    oePersona.Nombre = (string)reader["Nombre"];
                    oePersona.Edad = (int)reader["Edad"];
                    oePersona.Direccion = (string)reader["Direccion"];
                    oePersona.IDtrabajo = (int)reader["IDTrabajo"];
                    oePersona.IDPersona = (int)reader["IDPersona"];
                    lsPersonas.Add(oePersona);
                }
                reader.Close();
                return lsPersonas;
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

        public string Modificar_Postulante(int aceptado, int id_Persona)
        {
            try
            {
                SqlConnection con = db.ConectarDb();
                string update = string.Format("UPDATE Persona SET Aceptado = '{0}' WHERE IDPersona = {1}", aceptado, id_Persona);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                if (aceptado == 1)
                {
                    return "Se aceptó al postulante";
                }
                else
                    return "Se rechazó al postulante";
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

        public List<ePersona> ListarPostulantes(int aceptado)
        {
            try
            {
                ePersona persona = null;
                List<ePersona> lsPostulantes = new List<ePersona>();
                SqlConnection con = db.ConectarDb();
                string select = string.Format("SELECT Nombre,Edad,Direccion,IDTrabajo,IDPersona FROM Persona WHERE Aceptado={0}", aceptado);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    persona = new ePersona();
                    persona.IDPersona = (int)reader["IDPersona"];
                    persona.Nombre = (string)reader["Nombre"];
                    persona.Edad = (int)reader["Edad"];
                    persona.Direccion = (string)reader["Direccion"];
                    persona.IDtrabajo = (int)reader["IDTrabajo"];
                    lsPostulantes.Add(persona);
                }
                reader.Close();
                return lsPostulantes;
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
