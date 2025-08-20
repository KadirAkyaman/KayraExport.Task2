using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}