using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Sale
{
    public long SaleId { get; set; }

    public string? Description { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? FinalizedAt { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<ScheduledService> ScheduledServices { get; set; } = new List<ScheduledService>();
}
