using Microsoft.EntityFrameworkCore;
using Traversal_Web_Api.DAL.Entities;

namespace Traversal_Web_Api.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;initial catalog=TraversalApiDB;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
