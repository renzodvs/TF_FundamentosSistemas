using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class nEmpresa
    {
        dEmpresa empresadao;
        public nEmpresa()
        {
            empresadao = new dEmpresa();
        }
        public string RegistrarEmpresa(string Nombre_Empresa)
        {
            eEmpresa empresa = new eEmpresa()
            {
                NombreEmpresa = Nombre_Empresa
            };
            return empresadao.Insertar(empresa);
        }
        public string ModificarEmpresa(int id_Empresa, string Nombre_Empresa)
        {
            eEmpresa empresa = new eEmpresa()
            {
                idEmpresa = id_Empresa,
                NombreEmpresa = Nombre_Empresa
            };
            return empresadao.Modificar(empresa);
        }
        public string EliminarEmpres(int id_Empresa)
        {
            return empresadao.Eliminar(id_Empresa);
        }

        public List<eEmpresa>ListarEmpresa()
        {
            return empresadao.ListarTodo();
        }
    }
}
