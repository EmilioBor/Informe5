using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class PacienteDtoIn
    {
        public int Id { get; set; }

        public string? Apellido { get; set; }

        public string? Nombre { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        public int NumAfiliado { get; set; }

        public string? Sexo { get; set; }
    }
}
