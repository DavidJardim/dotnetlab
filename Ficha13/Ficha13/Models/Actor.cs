using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class Actor
    {
        public Actor()
        {
            FilmActors = new HashSet<FilmActor>();
        }

        public short ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<FilmActor> FilmActors { get; set; }
    }
}
