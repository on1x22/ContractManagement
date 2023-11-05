using CMBackend.DAL.ContextModels;
using CMBackend.DAL.Repository;

namespace CMBackend.Domain
{
    public class ContractsService : IContractsService
    {
        private readonly IContractsManagementRepository repository;

        public ContractsService(IContractsManagementRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Contract>> GetContractsAsync() =>
            await repository.GetContractsFromDbAsync();

        public async Task<List<ContractStage>> GetContractStagesAsync() =>
            await repository.GetContractStagesFromDbAsync();
    }
}
