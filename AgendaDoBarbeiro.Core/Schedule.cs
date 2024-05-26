using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Schedule
{
    public long ScheduleId { get; set; }

    public long? ProfessionalId { get; set; }

    public long? CustomerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public string? ScheduleStatus { get; set; }

    public virtual User? Customer { get; set; }

    public virtual User? Professional { get; set; }

    public virtual ICollection<ScheduledService> ScheduledServices { get; set; } = new List<ScheduledService>();
}
