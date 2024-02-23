using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class EntregaDtoOut
    {
        public int Desde { get; set; }

        public int Hasta { get; set; }

        public string? NombreObraSocial { get; set; }

        public string? NombreOdontologo { get; set; }
    }
}
