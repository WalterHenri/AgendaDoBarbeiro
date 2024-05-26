using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Ean { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? ExternalId { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
