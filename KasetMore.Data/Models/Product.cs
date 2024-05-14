using System;
using System.Collections.Generic;

namespace KasetMore.Data.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Province { get; set; } = null!;

    public double Rating { get; set; }

    public int Amount { get; set; }

    public string UserEmail { get; set; } = null!;

    public decimal Price { get; set; }

    public string Image { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual User UserEmailNavigation { get; set; } = null!;
}
