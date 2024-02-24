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
    public class OdontologoService : IOdontologoService
    {
        private readonly Informe4Context _context;
        public OdontologoService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OdontologoDtoOut>> GetAll()
        {
            return await _context.Odontologo.Select(n => new OdontologoDtoOut
            {
                //Id = n.Id,
                Nombre = n.Nombre,
                Apellido = n.Apellido,
                Dni = n.Dni,
                Matricula = n.Matricula,
                NombreOdontologoEstado = n.IdOdontologoEstadoNavigation.Nombre
                

            }).ToListAsync();

        }

        public async Task<OdontologoDtoOut?> GetDtoById(int id)
        {
            return await _context.Odontologo
                .Where(n => n.Id == id)
                .Select(n => new OdontologoDtoOut
                {
                    //Id = n.Id,
                    Nombre = n.Nombre,
                    Apellido = n.Apellido,
                    Dni = n.Dni,
                    Matricula = n.Matricula,
                    NombreOdontologoEstado = n.IdOdontologoEstadoNavigation.Nombre

                }).SingleOrDefaultAsync();

        }

        public async Task<Odontologo?> GetById(int id)
        {
            return await _context.Odontologo.FindAsync(id);
        }

        public async Task<Odontologo> Create(OdontologoDtoIn newOdontologoDTO)
        {
            var newOdontologo = new Odontologo();

            newOdontologo.Nombre = newOdontologoDTO.Nombre;
            newOdontologo.Apellido = newOdontologoDTO.Apellido;
            newOdontologo.Matricula = newOdontologoDTO.Matricula;
            newOdontologo.Dni = newOdontologoDTO.Dni;
            newOdontologo.IdOdontologoEstado = newOdontologoDTO.IdOdontologoEstado;


            _context.Odontologo.Add(newOdontologo);
            await _context.SaveChangesAsync();

            return newOdontologo;

        }

        public async Task Update(int id, OdontologoDtoIn odontologo)
        {
            var existingOdontologo = await GetById(id);

            if (existingOdontologo is not null)
            {

                existingOdontologo.Nombre = odontologo.Nombre;
                existingOdontologo.Apellido = odontologo.Apellido;
                existingOdontologo.Matricula = odontologo.Matricula;
                existingOdontologo.Dni = odontologo.Dni;
                existingOdontologo.IdOdontologoEstado = odontologo.IdOdontologoEstado;

                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var odontologoToDelete = await GetById(id);

            if (odontologoToDelete is not null)
            {

                _context.Odontologo.Remove(odontologoToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
