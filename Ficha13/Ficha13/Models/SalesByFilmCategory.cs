using System;
using System.Collections.Generic;

#nullable disable

namespace Ficha13.Models
{
    public partial class SalesByFilmCategory
    {
        public string Category { get; set; }
        public decimal? TotalSales { get; set; }
    }
}
