﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class PracticaDtoIn
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int Numero { get; set; }

        public float Valor { get; set; }
    }
}
