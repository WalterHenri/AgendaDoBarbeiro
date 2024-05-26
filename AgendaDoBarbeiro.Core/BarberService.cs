using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class BarberService
{
    public long BarberServiceId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int EstimatedTime { get; set; }

    public virtual ICollection<ProfessionalService> ProfessionalServices { get; set; } = new List<ProfessionalService>();

    public virtual ICollection<ScheduledService> ScheduledServices { get; set; } = new List<ScheduledService>();
}
