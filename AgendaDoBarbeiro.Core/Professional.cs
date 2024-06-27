using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Professional
{
    public long ProfessionalId { get; set; }

    public string? Whatsapp { get; set; }

    public string? FirstMessage { get; set; }

    public string? Description { get; set; }

    public long? EnterpriseId { get; set; }

    public virtual Enterprise? Enterprise { get; set; }

    public virtual User ProfessionalNavigation { get; set; } = null!;
}
