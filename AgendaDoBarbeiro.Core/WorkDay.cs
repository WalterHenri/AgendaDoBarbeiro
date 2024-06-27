using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class WorkDay
{
    public long WorkDayId { get; set; }

    public TimeOnly? StartAt { get; set; }

    public TimeOnly? ClosesAt { get; set; }

    public string? Day { get; set; }
}
