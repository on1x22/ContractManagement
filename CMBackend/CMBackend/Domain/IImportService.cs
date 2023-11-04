using CMBackend.DAL.ContextModels;

namespace CMBackend.Domain
{
    public interface IImportService
    {
        /*Task AddContracts(List<Contract> contracts);
        Task AddContractStages(List<ContractStage> contractStages);*/
        Task<bool> UploadFileAsync(List<Contract> contracts, List<ContractStage> contractStages);
    }
}
