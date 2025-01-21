using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eTrabajo
    {
        public string Area { get; set; }
        public int AñosDeExperiencia { get; set; }
        public decimal Sueldo { get; set; }
        public string LugarDeEmpleo { get; set; }
        public int NumeroDeVacantes { get; set; }
        public int IDtrabajo { get; set; }

        public eEmpresa Empresa { get; set; }
        public override string ToString()
        {
            return "Código: " + IDtrabajo + "   Empresa: " + Empresa.NombreEmpresa + "   Área: " + Area;
        }
    }
}
