using CMBackend.DAL.ContextModels;

namespace CMBackend.Domain
{
    public interface IContractsService
    {
        Task<List<Contract>> GetContractsAsync();
        Task<List<ContractStage>> GetContractStagesAsync();
    }
}
