using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class ProfessionalService
{
    public long ProfessionalServiceId { get; set; }

    public long? BarberServiceId { get; set; }

    public long? ProfessionalId { get; set; }

    public virtual BarberService? BarberService { get; set; }

    public virtual User? Professional { get; set; }
}
