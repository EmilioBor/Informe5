using Data.Models;

namespace Core.Request
{
    public class BonoDtoIn
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime FechaCarga { get; set; }

        public int Numero { get; set; }

        public int IdOdontologo { get; set; }

        public int IdObraSocial { get; set; }

        public int IdPractica { get; set; }

        public int IdPaciente { get; set; }

        public int IdBonoEstado { get; set; }
    }
}
