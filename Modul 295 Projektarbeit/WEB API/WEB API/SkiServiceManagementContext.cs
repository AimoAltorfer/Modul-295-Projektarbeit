using Microsoft.EntityFrameworkCore;
using WEB_API;

public class SkiServiceManagementContext : DbContext
{
    public SkiServiceManagementContext(DbContextOptions<SkiServiceManagementContext> options)
        : base(options)
    {
    }

    // DbSets für Ihre Entitäten
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<DeletedOrder> DeletedOrders { get; set; }

}
