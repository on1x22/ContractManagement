using CMBackend.DAL.ContextModels;
using CMBackend.DAL.Repository;

namespace CMBackend.Domain
{
    public class ImportService : IImportService
    {
        private readonly IContractsManagementRepository repository;

        public ImportService(IContractsManagementRepository repository)
        {
            this.repository = repository;
        }
        /*public Task AddContracts(List<Contract> contracts)
        {
            repository.
        }

        public Task AddContractStages(List<ContractStage> contractStages)
        {
            throw new NotImplementedException();
        }*/

        public async Task<bool> UploadFileAsync(List<Contract> contracts, List<ContractStage> contractStages)
        {
            await repository.AddContractsToDbAsync(contracts);
            await repository.AddContractStagesToDbAsync(contractStages);
            await repository.SaveChangesAsync();
            return true;
        }

        private async Task SaveChanges() =>
            await repository.SaveChangesAsync();
    }
}
