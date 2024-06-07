using static whozthere_blazor.Pages.AddTenant;

namespace whozthere_blazor
{
    public class PersonVisitor
    {
        public int PersonVisitorId { get; set; }

        public int PersonId { get; set; }

        public int VisitorId { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public virtual Person Person { get; set; } = null!;

        public virtual Visitor Visitor { get; set; } = null!;
    }
}
