using ApiCorePersonajesAWS.Models;
using ApiCorePersonajesAWS.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace ApiCorePersonajesAWS.Repositories
{
    public class PersonajesRepository
    {
        private PersonajesContext context;
        public PersonajesRepository(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            List<Personaje> personajes = await this.context.Personajes
                .ToListAsync();
            return personajes.Count == 0 ? null : personajes;
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }
        private async Task<int> GetMaxIdPersonajeAsync()
        {
            return await this.context.Personajes
                .MaxAsync(x => x.IdPersonaje) + 1;
        }

        public async Task<Personaje> InsertPersonajeAsync
            (string nombre, string imagen)
        {
            Personaje pers = new Personaje()
            {
                IdPersonaje = await this.GetMaxIdPersonajeAsync(),
                Imagen = imagen,
                Nombre = nombre
            };
            await this.context.Personajes.AddAsync(pers);
            await this.context.SaveChangesAsync();
            return pers;
        }

        public async Task UpdatePersonaje(int id,string nombre, string imagen)
        {
            Personaje pers = await this.FindPersonajeAsync(id);
            pers.Nombre=nombre;
            pers.Imagen=imagen;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonaje(int id)
        {
            Personaje personaje = await this.context
                .Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }

    }
}
