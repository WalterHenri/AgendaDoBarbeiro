using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Review
{
    public long ReviewId { get; set; }

    public long CustomerId { get; set; }

    public long ScheduledServiceId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual ScheduledService ScheduledService { get; set; } = null!;
}
