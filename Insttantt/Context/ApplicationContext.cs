using Insttantt.Models;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        public DbSet<StepsCatalog> StepsCatalogs { get; set; }
        public DbSet<FielsCatalog> FielsCatalogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserField> UserFields { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<FlowConfig> FlowConfigs { get; set; }
    }
}
