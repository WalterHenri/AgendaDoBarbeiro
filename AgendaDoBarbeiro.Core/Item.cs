using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Item
{
    public long ItemId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Discount { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
