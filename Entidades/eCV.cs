using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCV
    {
        public string Oficio { get; set; }
        public int AñosDeExperiencia { get; set; }
        public int NumeroTrabajosAnteriores { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
           return Nombre;
        }
    }
}
