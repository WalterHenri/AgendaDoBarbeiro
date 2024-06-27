using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class ProfessionalWorkDay
{
    public long? ProfessionalId { get; set; }

    public long? WorkDayId { get; set; }

    public virtual Professional? Professional { get; set; }

    public virtual WorkDay? WorkDay { get; set; }
}
