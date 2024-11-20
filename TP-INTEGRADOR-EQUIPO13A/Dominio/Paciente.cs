using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente
    {
        public Persona DatosPersona { get; set; }
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario = new Usuario();
        public Paciente()
        {
            DatosPersona = new Persona();
        }
        public bool activo { get; set; }
    }

}
