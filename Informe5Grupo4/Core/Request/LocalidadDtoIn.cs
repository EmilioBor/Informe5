using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class LocalidadDtoIn
    {
        public int Id { get; set; }

        public int Cp { get; set; }

        public string? Descripcion { get; set; }

        public int IdProvincia { get; set; }
    }
}
