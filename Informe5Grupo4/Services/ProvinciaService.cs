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
    public class ProvinciaService : IProvinciaService
    {
        private readonly Informe4Context _context;
        public ProvinciaService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProvinciaDtoOut>> GetAll()
        {
            return await _context.Provincia.Select(n => new ProvinciaDtoOut
            {
                //Id = n.Id,
                Descripcion = n.Descripcion

            }).ToListAsync();

        }

        public async Task<ProvinciaDtoOut?> GetDtoById(int id)
        {
            return await _context.Provincia
                .Where(n => n.Id == id)
                .Select(n => new ProvinciaDtoOut
                {
                    //Id = n.Id,
                    Descripcion = n.Descripcion


                }).SingleOrDefaultAsync();

        }

        public async Task<Provincia?> GetById(int id)
        {
            return await _context.Provincia.FindAsync(id);
        }

        public async Task<Provincia> Create(ProvinciaDtoIn newProvinciaDTO)
        {
            var newProvincia = new Provincia();

            newProvincia.Descripcion = newProvinciaDTO.Descripcion;


            _context.Provincia.Add(newProvincia);
            await _context.SaveChangesAsync();

            return newProvincia;

        }

        public async Task Update(int id, ProvinciaDtoIn provincia)
        {
            var existingProvincia = await GetById(id);

            if (existingProvincia is not null)
            {

                existingProvincia.Descripcion = provincia.Descripcion;


                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var provinciaToDelete = await GetById(id);

            if (provinciaToDelete is not null)
            {

                _context.Provincia.Remove(provinciaToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
