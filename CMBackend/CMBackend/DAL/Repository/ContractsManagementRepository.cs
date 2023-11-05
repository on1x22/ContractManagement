using Microsoft.EntityFrameworkCore;
using CMBackend.DAL.ContextModels;
using CMBackend.DAL.Contexts;

namespace CMBackend.DAL.Repository
{
    public class ContractsManagementRepository : IContractsManagementRepository
    {
        private readonly ContractsManagementDbContext context;
        public ContractsManagementRepository(ContractsManagementDbContext context)
        {
            this.context = context;
        }

        public async Task AddContractsToDbAsync(List<Contract> contracts) =>
            await context.Contracts.AddRangeAsync(contracts);

        public async Task AddContractStagesToDbAsync(List<ContractStage> contractStages) =>
            await context.ContractStages.AddRangeAsync(contractStages);

        public async Task<List<Contract>> GetContractsFromDbAsync() =>
            await context.Contracts.ToListAsync();

        public async Task<List<ContractStage>> GetContractStagesFromDbAsync() =>
            await context.ContractStages.ToListAsync();

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();
    }
}
