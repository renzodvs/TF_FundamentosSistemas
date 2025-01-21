using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ePersona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int IDtrabajo { get; set; }
        public int IDPersona { get; set; }
        public int Aceptado { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
