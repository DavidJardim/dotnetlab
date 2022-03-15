using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public short CityId { get; set; }
        public string City1 { get; set; }
        public short CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
