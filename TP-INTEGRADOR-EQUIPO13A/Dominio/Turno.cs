using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int id_paciente { get; set; }
        public int id_profesional { get; set; }
        public int id_especialidad { get; set; }
        public int IdInstitucion { get; set; }
        public string Institucion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public Paciente Paciente { get; set; } = new Paciente();
        public Profesional Profesional { get; set; } = new Profesional();
        public Especialidad Especialidad { get; set; } = new Especialidad();
       
    }
}
