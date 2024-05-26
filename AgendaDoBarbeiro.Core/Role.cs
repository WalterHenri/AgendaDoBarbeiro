using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class Role
{
    public long RoleId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
