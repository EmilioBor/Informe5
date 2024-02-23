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

namespace Services
{
    public class BonoEstadoService : IBonoEstadoService
    {
        private readonly Informe4Context _context;
        public BonoEstadoService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BonoEstadoDtoOut>> GetAll()
        {
            return await _context.BonoEstado.Select(n => new BonoEstadoDtoOut
            {
                //Id = n.Id,
                Nombre = n.Nombre

            }).ToListAsync();

        }

        public async Task<BonoEstadoDtoOut?> GetDtoById(int id)
        {
            return await _context.BonoEstado
                .Where(n => n.Id == id)
                .Select(n => new BonoEstadoDtoOut
                {
                    //Id = n.Id,
                    Nombre = n.Nombre
                }).SingleOrDefaultAsync();

        }

        public async Task<BonoEstado?> GetById(int id)
        {
            return await _context.BonoEstado.FindAsync(id);
        }

        public async Task<BonoEstado> Create(BonoEstadoDtoIn newBonoEstadoDTO)
        {
            var newBonoEstado = new BonoEstado();

            newBonoEstado.Nombre = newBonoEstadoDTO.Nombre;

            _context.BonoEstado.Add(newBonoEstado);
            await _context.SaveChangesAsync();

            return newBonoEstado;

        }

        public async Task Update(int id, BonoEstadoDtoIn bonoEstado)
        {
            var existingBonoEstado = await GetById(id);

            if (existingBonoEstado is not null)
            {

                
                existingBonoEstado.Nombre = bonoEstado.Nombre;
                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var bonoEstadoToDelete = await GetById(id);

            if (bonoEstadoToDelete is not null)
            {

                _context.BonoEstado.Remove(bonoEstadoToDelete);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<ProvinciaDtoOut>> IBonoEstadoService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Provincia?> IBonoEstadoService.GetById(int id)
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
