using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nPersona
    {
        private dPersona odPersona;
        public nPersona()
        {
            odPersona = new dPersona();
        }
        public string Registrar(string Nombre_,int Edad_,string Direccion_,int IDTrabajo_)
        {
            ePersona oePersona = new ePersona()
            {
                Nombre = Nombre_,
                Edad = Edad_,
                Direccion = Direccion_,
                IDtrabajo = IDTrabajo_
            };
            return odPersona.Insertar(oePersona);
        }
        public string Eliminar(int IDPersona_)
        {
            return odPersona.Eliminar(IDPersona_);
        }
        public string Modificar(ePersona oePersona)
        {
            return odPersona.Modificar(oePersona);
        }
        public List<ePersona> ListarPersona()
        {
            return odPersona.ListarTodo();
        }
        public string AceptarPostulante(int id_Persona)
        {
            return odPersona.Modificar_Postulante(1, id_Persona);
        }

        public string RechazarPostulante(int id_Persona)
        {
            return odPersona.Modificar_Postulante(0, id_Persona);
        }

        public List<ePersona> ListarPostulantesAceptados()
        {
            return odPersona.ListarPostulantes(1);
        }

    }
}
