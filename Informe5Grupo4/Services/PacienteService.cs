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
    public class PacienteService : IPacienteService
    {
        private readonly Informe4Context _context;
        public PacienteService(Informe4Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PacienteDtoOut>> GetAll()
        {
            return await _context.Paciente.Select(n => new PacienteDtoOut
            {
                //Id = n.Id,
                Nombre = n.Nombre,
                Apellido = n.Apellido,
                FechaNacimiento = n.FechaNacimiento,
                NumAfiliado = n.NumAfiliado,
                Sexo = n.Sexo


            }).ToListAsync();

        }

        public async Task<PacienteDtoOut?> GetDtoById(int id)
        {
            return await _context.Paciente
                .Where(n => n.Id == id)
                .Select(n => new PacienteDtoOut
                {
                    //Id = n.Id,
                    Nombre = n.Nombre,
                    Apellido = n.Apellido,
                    FechaNacimiento = n.FechaNacimiento,
                    NumAfiliado = n.NumAfiliado,
                    Sexo = n.Sexo

                }).SingleOrDefaultAsync();

        }

        public async Task<Paciente?> GetById(int id)
        {
            return await _context.Paciente.FindAsync(id);
        }

        public async Task<Paciente> Create(PacienteDtoIn newPacienteDTO)
        {
            var newPaciente = new Paciente();

            newPaciente.Nombre = newPacienteDTO.Nombre;
            newPaciente.Apellido = newPacienteDTO.Apellido;
            newPaciente.FechaNacimiento = newPacienteDTO.FechaNacimiento;
            newPaciente.NumAfiliado = newPacienteDTO.NumAfiliado;
            newPaciente.Sexo = newPacienteDTO.Sexo;


            _context.Paciente.Add(newPaciente);
            await _context.SaveChangesAsync();

            return newPaciente;

        }

        public async Task Update(int id, PacienteDtoIn paciente)
        {
            var existingPaciente = await GetById(id);

            if (existingPaciente is not null)
            {


                existingPaciente.Nombre = paciente.Nombre;
                existingPaciente.Apellido = paciente.Apellido;
                existingPaciente.FechaNacimiento = paciente.FechaNacimiento;
                existingPaciente.NumAfiliado = paciente.NumAfiliado;
                existingPaciente.Sexo = paciente.Sexo;


                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var pacienteToDelete = await GetById(id);

            if (pacienteToDelete is not null)
            {

                _context.Paciente.Remove(pacienteToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
