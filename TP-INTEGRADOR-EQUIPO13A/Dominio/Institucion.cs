using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Institucion
    {
        public int IdInstitucion { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Apertura { get; set; }
        public string Nombre { get; set; }

        public bool Activo { get; set; }
    }
}
