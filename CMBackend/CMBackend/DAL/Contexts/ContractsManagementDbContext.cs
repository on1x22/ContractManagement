using Microsoft.EntityFrameworkCore;
using CMBackend.DAL.ContextModels;

namespace CMBackend.DAL.Contexts
{
    public class ContractsManagementDbContext : DbContext
    {
        public ContractsManagementDbContext(DbContextOptions<ContractsManagementDbContext> options) : base(options)
        { }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractStage> ContractStages { get; set; }
    }
}
