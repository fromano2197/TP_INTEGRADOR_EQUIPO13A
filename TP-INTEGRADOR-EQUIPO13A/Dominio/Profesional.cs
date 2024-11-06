using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Profesional
    {
        public Usuario Usuario { get; set; } = new Usuario();
        public Persona Persona { get; set; } = new Persona();
        public Especialidad Especialidad { get; set; } = new Especialidad();
        public List<Especialidad> Especialidades { get; set; } = new List<Especialidad>();
        public int Estado { get; set; }
        public DateTime FechaIngreso { get; set; } = new DateTime();
        public int Matricula { get; set; }
        public Institucion Institucion { get; set; } = new Institucion();
    }
}
