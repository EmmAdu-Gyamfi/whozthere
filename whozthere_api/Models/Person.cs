using System;
using System.Collections.Generic;

namespace whozthere_api.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string Lastname { get; set; } = null!;

    public string Othernames { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DoB { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<PersonVisitor> PersonVisitors { get; set; } = new List<PersonVisitor>();

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
