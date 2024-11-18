﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Contacto ContactoCliente { get; set; } = new Contacto();
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }


    }
}
