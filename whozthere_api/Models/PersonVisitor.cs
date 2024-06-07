using System;
using System.Collections.Generic;

namespace whozthere_api.Models;

public partial class PersonVisitor
{
    public int PersonVisitorId { get; set; }

    public int PersonId { get; set; }

    public int VisitorId { get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Visitor Visitor { get; set; } = null!;
}
