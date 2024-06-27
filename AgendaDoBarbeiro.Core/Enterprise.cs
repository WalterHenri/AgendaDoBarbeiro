using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Enterprise
{
    public long EnterpriseId { get; set; }

    public string Name { get; set; } = null!;

    public string SocialName { get; set; } = null!;

    public string? Cnpj { get; set; }

    public string? Cpf { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<BarberService> BarberServices { get; set; } = new List<BarberService>();

    public virtual ICollection<Professional> Professionals { get; set; } = new List<Professional>();
}
