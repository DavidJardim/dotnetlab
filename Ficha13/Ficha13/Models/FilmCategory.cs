using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class FilmCategory
    {
        public short FilmId { get; set; }
        public byte CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}
