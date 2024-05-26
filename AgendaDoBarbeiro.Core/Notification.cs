using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Notification
{
    public long NotificationId { get; set; }

    public long? RecipientId { get; set; }

    public string? Message { get; set; }

    public DateTime? SentAt { get; set; }

    public virtual User? Recipient { get; set; }
}
