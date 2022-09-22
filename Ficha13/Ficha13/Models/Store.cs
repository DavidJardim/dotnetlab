using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            Inventories = new HashSet<Inventory>();
            staff = new HashSet<staff>();
        }

        public byte StoreId { get; set; }
        public byte ManagerStaffId { get; set; }
        public short AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual staff ManagerStaff { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
