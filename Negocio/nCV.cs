using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nCV
    {
        private dCV odCV;
        public nCV()
        {
            odCV = new dCV();
        }
        public string Registrar(string Oficio_,int AñosDeExperiencia_,int NumeroTrabajosAteriores_,string Nombre_)
        {
            eCV oeCV = new eCV()
            {
                Oficio = Oficio_,
                AñosDeExperiencia = AñosDeExperiencia_,
                NumeroTrabajosAnteriores = NumeroTrabajosAteriores_,
                Nombre = Nombre_
            };
            return odCV.Insertar(oeCV);
        }
        public string Eliminar(string Nombre_)
        {
            return odCV.Eliminar(Nombre_);
        }
        public string Modificar(eCV oeCV)
        {
            return odCV.Modificar(oeCV);
        }
        public List<eCV> ListarCV()
        {
            return odCV.ListarTodo();
        }
        public string ModificarNombre(ePersona oePersona)
        {
            return odCV.ModificarNombre(oePersona.Nombre);
        }
    }
}
