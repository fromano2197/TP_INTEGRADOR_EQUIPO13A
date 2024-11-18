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
        public DateTime Fecha { get; set; }
        public TimeSpan Hora  { get; set; }
        public Paciente Paciente { get; set; }
        public Profesional Profesional { get; set; }
        public Especialidad Especialidad { get; set; }
        public bool Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
