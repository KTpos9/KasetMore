using System;
using System.Collections.Generic;

namespace KasetMore.Data.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int SellerEmail { get; set; }

    public int BuyerEmail { get; set; }

    public int ProductId { get; set; }

    public string Unit { get; set; } = null!;

    public int Amount { get; set; }

    public double Price { get; set; }

    public DateTime? CreateDate { get; set; }
}
