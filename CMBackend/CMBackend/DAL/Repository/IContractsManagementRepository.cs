using CMBackend.DAL.ContextModels;

namespace CMBackend.DAL.Repository
{
    public interface IContractsManagementRepository
    {
        Task AddContractsToDbAsync(List<Contract> contracts);
        Task AddContractStagesToDbAsync(List<ContractStage> contractStages);
        //Task<bool> UploadFile();
        Task<List<Contract>> GetContractsFromDbAsync();
        Task<List<ContractStage>> GetContractStagesFromDbAsync();
        Task SaveChangesAsync();
    }
}
