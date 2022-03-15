using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class CustomerList
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public byte Sid { get; set; }
    }
}
