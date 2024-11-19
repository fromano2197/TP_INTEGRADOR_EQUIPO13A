using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estudio
    {
        public int IdEstudio { get; set; }
        public int IdPaciente { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public string TipoEstudio { get; set; }
        public DateTime FechaEstudio { get; set; }
    }
}
