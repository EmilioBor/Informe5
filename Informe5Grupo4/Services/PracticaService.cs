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
    public class PracticaService : IPracticaService
    {
        private readonly Informe4Context _context;
        public PracticaService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PracticaDtoOut>> GetAll()
        {
            return await _context.Practica.Select(n => new PracticaDtoOut
            {
                //Id = n.Id,
                Nombre = n.Nombre,
                Numero = n.Numero,
                Valor = n.Valor

            }).ToListAsync();

        }

        public async Task<PracticaDtoOut?> GetDtoById(int id)
        {
            return await _context.Practica
                .Where(n => n.Id == id)
                .Select(n => new PracticaDtoOut
                {
                    //Id = n.Id,
                    Nombre = n.Nombre,
                    Numero = n.Numero,
                    Valor = n.Valor


                }).SingleOrDefaultAsync();

        }

        public async Task<Practica?> GetById(int id)
        {
            return await _context.Practica.FindAsync(id);
        }

        public async Task<Practica> Create(PracticaDtoIn newPracticaDTO)
        {
            var newPractica = new Practica();

            newPractica.Nombre = newPracticaDTO.Nombre;
            newPractica.Numero = newPracticaDTO.Numero;
            newPractica.Valor = newPracticaDTO.Valor;

            _context.Practica.Add(newPractica);
            await _context.SaveChangesAsync();

            return newPractica;

        }

        public async Task Update(int id, PracticaDtoIn practica)
        {
            var existingPractica = await GetById(id);

            if (existingPractica is not null)
            {


                existingPractica.Nombre = practica.Nombre;
                existingPractica.Numero = practica.Numero;
                existingPractica.Valor = practica.Valor;


                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var practicaToDelete = await GetById(id);

            if (practicaToDelete is not null)
            {

                _context.Practica.Remove(practicaToDelete);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<ProvinciaDtoOut>> IPracticaService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Provincia?> IPracticaService.GetById(int id)
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
