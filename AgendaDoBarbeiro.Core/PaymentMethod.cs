using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class PaymentMethod
{
    public long PaymentMethodId { get; set; }

    public string Description { get; set; } = null!;

    public long? SaleId { get; set; }

    public virtual Sale? Sale { get; set; }
}
