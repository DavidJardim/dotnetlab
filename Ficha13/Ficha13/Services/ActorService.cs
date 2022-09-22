using Ficha13.Models;
using Microsoft.EntityFrameworkCore;

namespace Ficha13.Services
{
    public class ActorService : IActorService
    {
        private readonly SakilaContext context;

        public ActorService(SakilaContext context)
        {
            this.context = context;
        }

        public Actor Create(Actor newActor)
        {
            context.Actors.Add(newActor);
            context.SaveChanges();
            return newActor;
        }

        public void DeleteByID(short id)
        {
            var actorToDelete = context.Actors.Find(id);
            if (actorToDelete is not null)
            {
                context.Actors.Remove(actorToDelete);
                context.SaveChanges();
            }
        }

        public IEnumerable<Actor> GetAll()
        {
            //return context.Actors.Include(a => a.FilmActors).Take(5).ToList();
            return context.Actors
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.ActorId);
        }

        public Actor? GetById(short id)
        {
            return context.Actors.SingleOrDefault(a => a.ActorId == id);            
        }

        public Actor? Update(short id, Actor actor)
        {
            var actorToUpdate = context.Actors.Find(id);
            if (actorToUpdate is null)
            {
                return null;
            }
            else
            {
                actorToUpdate.FirstName = actor.FirstName;
                actorToUpdate.LastName = actor.LastName;                
                context.SaveChanges();
                return actorToUpdate;
            }
        }


        public IEnumerable<Film> GetFilms(short id)
        {        
            var query = context.FilmActors
                .Where(fa => fa.ActorId == 1)
                .Include(fa => fa.Film)
                .ThenInclude(f => f.Language)                
                .ToList();            

            List<Film> films = new List<Film>();
            
            foreach (var fa in query)
            {                
                films.Add(fa.Film);
            }
            return films;           
        }
    }
}
