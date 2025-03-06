using eFilm.Data.Base;
using eFilm.Data.Services.Interfaces;
using eFilm.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eFilm.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(ApplicationDbContext context) : base(context) { }
       
    }

}

            //public async Task AddAsync(Actor actor)
            //{
            //    await _context.ActorsTable.AddAsync(actor);
            //    await _context.SaveChangesAsync(); 
            //}


            //public async Task DeleteAsync(int id)
            //{
            //    var result = await _context.ActorsTable.FirstOrDefaultAsync(n => n.Id == id);
            //    _context.ActorsTable.Remove(result);
            //    await _context.SaveChangesAsync();

            //}


            //public async Task<Actor> UpdateAsync(int id, Actor newActor)
            //{
            //     _context.Update(newActor);
            //    await _context.SaveChangesAsync();
            //    return newActor;
            //}



        

