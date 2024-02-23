using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class BonoDtoOut
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }

        public DateOnly FechaCarga { get; set; }

        public int Numero { get; set; }

        public string? NombreOdontologo { get; set; }

        public string? NombreObraSocial { get; set; }

        public string? NombrePractica { get; set; }

        public string? NombrePaciente { get; set; }

        public string? NombreBonoEstado { get; set; }
    }
}
