using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class Rental
    {
        public Rental()
        {
            Payments = new HashSet<Payment>();
        }

        public int RentalId { get; set; }
        public int InventoryId { get; set; }
        public short CustomerId { get; set; }
        public byte StaffId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual staff Staff { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
