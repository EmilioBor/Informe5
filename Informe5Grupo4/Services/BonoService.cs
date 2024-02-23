using Core.Request;
using Core.Response;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public class BonoService : IBonoService
    {
        private readonly Informe4Context _context;
        public BonoService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BonoDtoOut>> GetAll()
        {
            return await _context.Bono.Select(n => new BonoDtoOut
            {
                Id = n.Id,
                Fecha = n.Fecha,
                FechaCarga = n.FechaCarga,
                Numero = n.Numero,
                NombreOdontologo = n.IdOdontologoNavigation.Nombre,
                NombreObraSocial = n.IdObraSocialNavigation.Nombre,
                NombrePractica = n.IdPracticaNavigation.Nombre,
                NombrePaciente = n.IdPacienteNavigation.Nombre,
                NombreBonoEstado = n.IdBonoEstadoNavigation.Nombre


            }).ToListAsync();

        }

        public async Task<BonoDtoOut?> GetDtoById(int id)
        {
            return await _context.Bono
                .Where(n => n.Id == id)
                .Select(n => new BonoDtoOut
                {
                    Id = n.Id,
                    Fecha = n.Fecha,
                    FechaCarga = n.FechaCarga,
                    Numero = n.Numero,
                    NombreOdontologo = n.IdOdontologoNavigation.Nombre,
                    NombreObraSocial = n.IdObraSocialNavigation.Nombre,
                    NombrePractica = n.IdPracticaNavigation.Nombre,
                    NombrePaciente = n.IdPacienteNavigation.Nombre,
                    NombreBonoEstado = n.IdBonoEstadoNavigation.Nombre

                }).SingleOrDefaultAsync();

        }

        public async Task<Bono?> GetById(int id)
        {
            return await _context.Bono.FindAsync(id);
        }

        public async Task<Bono> Create(BonoDtoIn newBonoDTO)
        {
            var newBono = new Bono();

            newBono.Fecha = newBonoDTO.Fecha;
            newBono.FechaCarga = newBonoDTO.FechaCarga;
            newBono.Numero = newBonoDTO.Numero;
            newBono.IdOdontologo = newBonoDTO.IdOdontologo;
            newBono.IdObraSocial = newBonoDTO.IdObraSocial;
            newBono.IdPractica = newBonoDTO.IdPractica;
            newBono.IdPaciente = newBonoDTO.IdPaciente;
            newBono.IdBonoEstado = newBonoDTO.IdBonoEstado;


            _context.Bono.Add(newBono);
            await _context.SaveChangesAsync();

            return newBono;

        }

        public async Task Update(int id, BonoDtoIn bono)
        {
            var existingBono = await GetById(id);

            if (existingBono is not null)
            {

                existingBono.Fecha = bono.Fecha;
                existingBono.FechaCarga = bono.FechaCarga;
                existingBono.Numero = bono.Numero;
                existingBono.IdOdontologo = bono.IdOdontologo;
                existingBono.IdObraSocial = bono.IdObraSocial;
                existingBono.IdPractica = bono.IdPractica;
                existingBono.IdPaciente = bono.IdPaciente;
                existingBono.IdBonoEstado = bono.IdBonoEstado;
                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var bonoToDelete = await GetById(id);

            if (bonoToDelete is not null)
            {

                _context.Bono.Remove(bonoToDelete);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<ProvinciaDtoOut>> IBonoService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Provincia?> IBonoService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Provincia> Create(ProvinciaDtoIn newProvinciaDTO)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, ProvinciaDtoIn provincia)
        {
            throw new NotImplementedException();
        }
    }
}
