using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class OdontologoDtoIn
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Matricula { get; set; }

        public int Dni { get; set; }

        public int IdOdontologoEstado { get; set; }
    }
}
