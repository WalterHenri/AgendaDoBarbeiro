using System;
using System.Collections.Generic;

namespace AgendaDoBarbeiro.Core;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<ProfessionalService> ProfessionalServices { get; set; } = new List<ProfessionalService>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Schedule> ScheduleCustomers { get; set; } = new List<Schedule>();

    public virtual ICollection<Schedule> ScheduleProfessionals { get; set; } = new List<Schedule>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
