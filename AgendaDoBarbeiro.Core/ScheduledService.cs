using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class ScheduledService
{
    public long ScheduledServiceId { get; set; }

    public long? BarberServiceId { get; set; }

    public long? ScheduleId { get; set; }

    public int EstimatedTime { get; set; }

    public decimal Price { get; set; }

    public virtual BarberService? BarberService { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Schedule? Schedule { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
