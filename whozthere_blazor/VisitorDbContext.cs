using Microsoft.EntityFrameworkCore;
using static whozthere_blazor.Pages.AddTenant;

namespace whozthere_blazor
{

    public partial class VisitorDbContext : DbContext
    {
        public VisitorDbContext()
        {
        }

        public VisitorDbContext(DbContextOptions<VisitorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<PersonVisitor> PersonVisitors { get; set; }

        public virtual DbSet<Visitor> Visitors { get; set; }

        public virtual DbSet<SyncData> SyncDatas { get; set; }






    }
}
