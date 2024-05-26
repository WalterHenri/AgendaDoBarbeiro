using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Address
{
    public long AddressId { get; set; }

    public long UserId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public virtual User User { get; set; } = null!;
}
