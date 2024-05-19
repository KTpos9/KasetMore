

using Microsoft.AspNetCore.Http;

namespace KasetMore.ApplicationCore.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string Province { get; set; } = null!;

        public double Rating { get; set; }

        public int Amount { get; set; }

        public string UserEmail { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual List<IFormFile> ProductImages { get; set; }
    }
}
