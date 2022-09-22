using Ficha13.Models;
using System.Collections.Generic;

namespace Ficha13.Services
{
    public interface IActorService
    {
        public abstract IEnumerable<Actor> GetAll();

        public abstract Actor? GetById(short id);

        public abstract Actor Create(Actor newActor);

        public abstract void DeleteByID(short id);

        public abstract Actor? Update(short id, Actor actor);

        public IEnumerable<Film> GetFilms(short id);
    }
}
