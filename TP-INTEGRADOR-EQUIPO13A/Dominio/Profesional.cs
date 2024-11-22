using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Profesional
    {
        public int IdProfesional { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public Persona Persona { get; set; } = new Persona();
        public Especialidad Especialidad { get; set; } = new Especialidad();
        public List<Especialidad> Especialidades { get; set; } = new List<Especialidad>();
        public bool Estado { get; set; }
        public DateTime FechaIngreso { get; set; } = new DateTime();
        public string Matricula { get; set; }
        public List<Institucion> Institucion { get; set; } = new List<Institucion>();
        public string NombreCompleto
        {
            get
            {
                return $"{Persona.Nombre} {Persona.Apellido}";
            }
        }
    }
}
