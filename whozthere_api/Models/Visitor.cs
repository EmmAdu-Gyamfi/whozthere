using System;
using System.Collections.Generic;

namespace whozthere_api.Models;

public partial class Visitor
{
    public int VisitorId { get; set; }

    public string Lastname { get; set; } = null!;

    public string Othernames { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<PersonVisitor> PersonVisitors { get; set; } = new List<PersonVisitor>();
}
