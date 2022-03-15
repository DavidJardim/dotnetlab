using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rentals = new HashSet<Rental>();
        }

        public int InventoryId { get; set; }
        public short FilmId { get; set; }
        public byte StoreId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
