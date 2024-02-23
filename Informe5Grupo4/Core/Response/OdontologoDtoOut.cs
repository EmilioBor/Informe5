using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class OdontologoDtoOut
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Matricula { get; set; }

        public int Dni { get; set; }

        public string? NombreOdontologoEstado { get; set; }
    }
}
