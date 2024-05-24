

using Microsoft.AspNetCore.Http;

namespace KasetMore.ApplicationCore.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; } = null!;

        public string Province { get; set; } = null!;

        public double Rating { get; set; }
        public string Category { get; set; }

        public int Amount { get; set; }

        public string UserEmail { get; set; } = null!;

        public decimal Price { get; set; }

        //public virtual List<IFormFile> ProductImages { get; set; }
    }
}
