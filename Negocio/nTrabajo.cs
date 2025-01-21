using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades; // <-
using Datos; // <-

namespace Negocio
{
    public class nTrabajo
    {
        private dTrabajo odTrabajo;
        public nTrabajo()
        {
            odTrabajo = new dTrabajo();
        }
        public string Registrar(string Area_, int AñosExperiencia_, decimal Sueldo_, string LugarEmpleo_, int NumeroVacantes_, int idEmpresa_)
        {
            eEmpresa oeEmpresa = new eEmpresa()
            {
                idEmpresa = idEmpresa_
            };
            eTrabajo oeTrabajo = new eTrabajo()
            {
                Area = Area_,
                AñosDeExperiencia = AñosExperiencia_,
                Sueldo = Sueldo_,
                LugarDeEmpleo = LugarEmpleo_,
                NumeroDeVacantes = NumeroVacantes_,
                Empresa = oeEmpresa
            };
            return odTrabajo.Insertar(oeTrabajo);
        }
        public string Remover(int IDtrabajo_)
        {
            return odTrabajo.Eliminar(IDtrabajo_);
        }
        public string Modificar(string Area_, int AñosExperiencia_, decimal Sueldo_, string LugarEmpleo_, int NumeroVacantes_, int idEmpresa_)
        {
            eEmpresa oeEmpresa = new eEmpresa()
            {
                idEmpresa = idEmpresa_
            };
            eTrabajo oeTrabajo = new eTrabajo()
            {
                Area = Area_,
                AñosDeExperiencia = AñosExperiencia_,
                Sueldo = Sueldo_,
                LugarDeEmpleo = LugarEmpleo_,
                NumeroDeVacantes = NumeroVacantes_,
                Empresa = oeEmpresa
            };
            return odTrabajo.Modificar(oeTrabajo);
        }
        public List<eTrabajo> ListarTrabajo()
        {
            return odTrabajo.ListarTodo();
        }
    }
}
