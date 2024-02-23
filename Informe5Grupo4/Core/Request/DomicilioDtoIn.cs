using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class DomicilioDtoIn
    {
        public int Id { get; set; }

        public string? Calle { get; set; }

        public string? Numero { get; set; }

        public int IdLocalidad { get; set; }

        public int IdOdontologo { get; set; }
    }
}
