using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Profesional
    {
        public Usuario Usuario { get; set; }
        public Persona Persona { get; set; }
        public Especialidad Especialidad { get; set; }
        public int Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Matricula { get; set; }
        public Institucion Institucion { get; set; }
    }
}
