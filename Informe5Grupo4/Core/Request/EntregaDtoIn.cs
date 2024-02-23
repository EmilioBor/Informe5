using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class EntregaDtoIn
    {
        public int Id { get; set; }

        public int Desde { get; set; }

        public int Hasta { get; set; }

        public int IdObraSocial { get; set; }

        public int IdOdontologo { get; set; }
    }
}
