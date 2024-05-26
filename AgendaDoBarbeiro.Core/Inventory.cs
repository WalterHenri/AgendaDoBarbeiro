using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Inventory
{
    public long InventoryId { get; set; }

    public int? ProductId { get; set; }

    public int? QuantityOnHand { get; set; }

    public int? ReorderLevel { get; set; }

    public virtual Product? Product { get; set; }
}
