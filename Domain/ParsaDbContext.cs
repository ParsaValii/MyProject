using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParsaDbContext : DbContext
    {
        public ParsaDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=FlowAley;Initial Catalog=ParsaDb;Integrated Security=True;TrustServerCertificate=True"
            );
        }
        public ParsaDbContext(DbContextOptions<ParsaDbContext> options)
            : base(options) { }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
    }
}
