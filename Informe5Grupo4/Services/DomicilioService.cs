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
    public class DomicilioService : IDomicilioService
    {
        private readonly Informe4Context _context;
        public DomicilioService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DomicilioDtoOut>> GetAll()
        {
            return await _context.Domicilio.Select(n => new DomicilioDtoOut
            {
                //Id = n.Id,
                Calle = n.Calle,
                Numero = n.Numero,
                NombreLocalidad = n.IdLocalidadNavigation.Descripcion,
                NombreOdontologo = n.IdOdontologoNavigation.Nombre


            }).ToListAsync();

        }

        public async Task<DomicilioDtoOut?> GetDtoById(int id)
        {
            return await _context.Domicilio
                .Where(n => n.Id == id)
                .Select(n => new DomicilioDtoOut
                {
                    //Id = n.Id,
                    Calle = n.Calle,
                    Numero = n.Numero,
                    NombreLocalidad = n.IdLocalidadNavigation.Descripcion,
                    NombreOdontologo = n.IdOdontologoNavigation.Nombre
                 

                }).SingleOrDefaultAsync();

        }

        public async Task<Domicilio?> GetById(int id)
        {
            return await _context.Domicilio.FindAsync(id);
        }

        public async Task<Domicilio> Create(DomicilioDtoIn newDomicilioDTO)
        {
            var newDomicilio = new Domicilio();

            newDomicilio.Calle = newDomicilioDTO.Calle;
            newDomicilio.Numero = newDomicilioDTO.Numero;
            newDomicilio.IdLocalidad = newDomicilioDTO.IdLocalidad;
            newDomicilio.IdOdontologo = newDomicilioDTO.IdOdontologo;


            _context.Domicilio.Add(newDomicilio);
            await _context.SaveChangesAsync();

            return newDomicilio;

        }

        public async Task Update(int id, DomicilioDtoIn domicilio)
        {
            var existingDomicilio = await GetById(id);

            if (existingDomicilio is not null)
            {

                
                existingDomicilio.Calle = domicilio.Calle;
                existingDomicilio.Numero = domicilio.Numero;
                existingDomicilio.IdLocalidad = domicilio.IdLocalidad;
                existingDomicilio.IdOdontologo = domicilio.IdOdontologo;


                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var domicilioToDelete = await GetById(id);

            if (domicilioToDelete is not null)
            {

                _context.Domicilio.Remove(domicilioToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
